using GestionAviones.Model;

namespace GestionAviones.BL
{
    public interface IAdministradorDeAviones
    {
        Task ActivarAsync(int id);
        Task DesActivarAsync(int id);
        Task AgregarAsync(Avion avion);
        Task<IEnumerable<Avion>> ObtengaLaListaAsync();
        Task<IEnumerable<Avion>> ObtengaLaListaDeActivosAsync();
        Task<IEnumerable<Avion>> ObtengaLaListaDeInActivosAsync();
        Task<Avion?> ObtengaElAvionAsync(int id);
        Task EditeElAvionAsync(Avion avion);
    }
}
