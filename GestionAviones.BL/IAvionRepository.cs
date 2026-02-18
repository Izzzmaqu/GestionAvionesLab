using GestionAviones.Model;

namespace GestionAviones.BL
{
    public interface IAvionRepository
    {
        Task<IEnumerable<Avion>> ObtenerAsync();
        Task<IEnumerable<Avion>> ObtenerActivosAsync();
        Task<IEnumerable<Avion>> ObtenerInActivosAsync();
        Task<Avion?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Avion avion);
        Task ActualizarAsync(Avion avion);
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
    }
}
