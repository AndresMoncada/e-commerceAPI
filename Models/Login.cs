using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingresa una dirección de correo electrónico válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string Password { get; set; }
    }
}
