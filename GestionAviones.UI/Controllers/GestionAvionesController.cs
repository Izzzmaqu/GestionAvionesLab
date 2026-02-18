using GestionAviones.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionAviones.UI.Controllers
{
    public class GestionAvionesController(ServicioApi servicioApi) : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Avion> lista;
            try
            {
                lista = (await servicioApi.ObtengaLaListaAsync()).ToList();
                ViewData["ProblemasAlConsultar"] = false;
            }
            catch
            {
                lista = [];
                ViewData["ProblemasAlConsultar"] = true;
            }
            return View(lista);
        }

        public async Task<ActionResult> Detalles(int id)
        {
            Avion avion = await servicioApi.ObtengaElAvionAsync(id);
            return View(avion);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Avion avion)
        {
            try
            {
                await servicioApi.AgregarAsync(avion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Editar(int id)
        {
            Avion avion = await servicioApi.ObtengaElAvionAsync(id);
            return View(avion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Avion avion)
        {
            try
            {
                await servicioApi.EditeElAvionAsync(avion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> DesActivar(int id)
        {
            try
            {
                await servicioApi.DesActivarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<ActionResult> Activar(int id)
        {
            try
            {
                await servicioApi.ActivarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
