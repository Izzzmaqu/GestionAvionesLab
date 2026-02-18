using GestionAviones.Model;

namespace GestionAviones.BL
{
    public class AdministradorDeAviones : IAdministradorDeAviones
    {
        private readonly IAvionRepository _avionRepository;

        public AdministradorDeAviones(IAvionRepository avionRepository)
        {
            _avionRepository = avionRepository;
        }

        public async Task ActivarAsync(int id)
        {
            await _avionRepository.ActivarAsync(id);
        }

        public async Task DesActivarAsync(int id)
        {
            await _avionRepository.DesActivarAsync(id);
        }

        public async Task AgregarAsync(Avion avion)
        {
            avion.Estado = Estado.Activo; // siempre se crea activo
            await _avionRepository.AgregarAsync(avion);
        }

        public async Task<IEnumerable<Avion>> ObtengaLaListaAsync()
        {
            return await _avionRepository.ObtenerAsync();
        }

        public async Task<IEnumerable<Avion>> ObtengaLaListaDeActivosAsync()
        {
            return await _avionRepository.ObtenerActivosAsync();
        }

        public async Task<IEnumerable<Avion>> ObtengaLaListaDeInActivosAsync()
        {
            return await _avionRepository.ObtenerInActivosAsync();
        }

        public async Task<Avion?> ObtengaElAvionAsync(int id)
        {
            return await _avionRepository.ObtenerPorIdAsync(id);
        }

        public async Task EditeElAvionAsync(Avion avion)
        {
            var avionAModificar = await _avionRepository.ObtenerPorIdAsync(avion.Id);
            if (avionAModificar != null)
            {
                avionAModificar.Nombre = avion.Nombre;
                avionAModificar.Modelo = avion.Modelo;
                await _avionRepository.ActualizarAsync(avionAModificar);
            }
        }
    }
}
