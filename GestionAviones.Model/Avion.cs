using System.ComponentModel.DataAnnotations;

namespace GestionAviones.Model
{
    public class Avion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(100, ErrorMessage = "El Nombre debe tener entre 2 y 100 caracteres", MinimumLength = 2)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Modelo es requerido")]
        [StringLength(50, ErrorMessage = "El Modelo debe tener entre 2 y 50 caracteres", MinimumLength = 2)]
        public string Modelo { get; set; }

        public Estado Estado { get; set; }
    }
}
