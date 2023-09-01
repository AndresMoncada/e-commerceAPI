using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Registro
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; }
    }

}
