using GestionAviones.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionAviones.UI.Controllers
{
    public class GestionAvionesInActivosController(ServicioApi servicioApi) : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Avion> lista;
            try
            {
                lista = (await servicioApi.ObtengaLaListaDeInActivosAsync()).ToList();
                ViewData["ProblemasAlConsultar"] = false;
            }
            catch
            {
                lista = [];
                ViewData["ProblemasAlConsultar"] = true;
            }
            return View(lista);
        }

        public async Task<ActionResult> Activar(int id)
        {
            Avion avion = await servicioApi.ObtengaElAvionAsync(id);
            return View(avion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Activar(Avion avion)
        {
            try
            {
                await servicioApi.ActivarAsync(avion.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
