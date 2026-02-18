using GestionAviones.BL;
using GestionAviones.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionAviones.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioDeAvionesController : ControllerBase
    {
        private readonly IAdministradorDeAviones _admin;

        public ServicioDeAvionesController(IAdministradorDeAviones admin)
        {
            _admin = admin;
        }

        [HttpGet("ObtengaLaLista")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtengaLaLista()
        {
            var lista = await _admin.ObtengaLaListaAsync();
            return Ok(lista);
        }

        [HttpGet("ObtengaLaListaDeActivos")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtengaLaListaDeActivos()
        {
            var lista = await _admin.ObtengaLaListaDeActivosAsync();
            return Ok(lista);
        }

        [HttpGet("ObtengaLaListaDeInActivos")]
        public async Task<ActionResult<IEnumerable<Avion>>> ObtengaLaListaDeInActivos()
        {
            var lista = await _admin.ObtengaLaListaDeInActivosAsync();
            return Ok(lista);
        }

        [HttpGet("ObtengaElAvion")]
        public async Task<ActionResult<Avion>> ObtengaElAvion(int id)
        {
            var avion = await _admin.ObtengaElAvionAsync(id);
            if (avion == null)
                return NotFound();
            return Ok(avion);
        }

        [HttpPost("Agregue")]
        public async Task<IActionResult> Agregue([FromBody] Avion avion)
        {
            await _admin.AgregarAsync(avion);
            return Ok();
        }

        [HttpPut("EditeElAvion")]
        public async Task<IActionResult> EditeElAvion([FromBody] Avion avion)
        {
            await _admin.EditeElAvionAsync(avion);
            return Ok();
        }

        [HttpPut("Active")]
        public async Task<IActionResult> Active(int id)
        {
            await _admin.ActivarAsync(id);
            return Ok();
        }

        [HttpPut("DesActive")]
        public async Task<IActionResult> DesActive(int id)
        {
            await _admin.DesActivarAsync(id);
            return Ok();
        }
    }
}
