using GestionAviones.Model;
using GestionAviones.BL;

namespace GestionAviones.DA
{
    public class AvionRepository : IAvionRepository
    {
        private static List<Avion> _aviones = new List<Avion>();
  
        private static int _nextId = 1;

        public Task<Avion?> ObtenerPorIdAsync(int id)
        {
            var avion = _aviones.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(avion);
        }

        public Task<IEnumerable<Avion>> ObtenerAsync()
        {
            return Task.FromResult<IEnumerable<Avion>>(_aviones);
        }

        public Task<IEnumerable<Avion>> ObtenerActivosAsync()
        {
            return Task.FromResult<IEnumerable<Avion>>(_aviones.Where(a => a.Estado == Estado.Activo).ToList());
        }

        public Task<IEnumerable<Avion>> ObtenerInActivosAsync()
        {
            return Task.FromResult<IEnumerable<Avion>>(_aviones.Where(a => a.Estado == Estado.Inactivo).ToList());
        }

        public Task AgregarAsync(Avion avion)
        {
            avion.Id = _nextId++;
            _aviones.Add(avion);
            return Task.CompletedTask;
        }

        public Task ActualizarAsync(Avion avion)
        {
            var existente = _aviones.FirstOrDefault(a => a.Id == avion.Id);
            if (existente != null)
            {
                var index = _aviones.IndexOf(existente);
                _aviones[index] = avion;
            }
            return Task.CompletedTask;
        }

        public Task ActivarAsync(int id)
        {
            var avion = _aviones.FirstOrDefault(a => a.Id == id);
            if (avion != null) avion.Estado = Estado.Activo;
            return Task.CompletedTask;
        }

        public Task DesActivarAsync(int id)
        {
            var avion = _aviones.FirstOrDefault(a => a.Id == id);
            if (avion != null) avion.Estado = Estado.Inactivo;
            return Task.CompletedTask;
        }
    }
}
