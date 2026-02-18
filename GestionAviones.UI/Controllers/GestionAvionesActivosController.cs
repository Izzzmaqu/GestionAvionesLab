using GestionAviones.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionAviones.UI.Controllers
{
    public class GestionAvionesActivosController(ServicioApi servicioApi) : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Avion> lista;
            try
            {
                lista = (await servicioApi.ObtengaLaListaDeActivosAsync()).ToList();
                ViewData["ProblemasAlConsultar"] = false;
            }
            catch
            {
                lista = [];
                ViewData["ProblemasAlConsultar"] = true;
            }
            return View(lista);
        }

        public async Task<ActionResult> InActivar(int id)
        {
            Avion avion = await servicioApi.ObtengaElAvionAsync(id);
            return View(avion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InActivar(Avion avion)
        {
            try
            {
                await servicioApi.DesActivarAsync(avion.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
