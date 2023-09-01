using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        public IUsuarioCollection db = new UsuarioCollection();

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var usuario = await db.ValidateLogin(model.Email, model.Password);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Credenciales incorrectas" });
            }

            return Ok(new { message = "Inicio de sesión exitoso" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registro(Registro model)
        {
            var usuarioExistente = await db
                .GetUsuarioByEmail(model.Email);

            if (usuarioExistente != null)
            {
                return BadRequest(new { message = "El usuario ya existe" });
            }

            var nuevoUsuario = new Usuario
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };

            await db.InsertUsuario(nuevoUsuario);

            return Ok(new { message = "Registro exitoso" });
        }

        [Route("getAllUsuarios")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            return Ok(await db.GetAllUsuarios());
        }


        [Route("getUsuarioById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUsuarioById(string id)
        {
            return Ok(await db.GetUsuarioById(id));
        }

        [Route("createUsuario")]
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (usuario.Name == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre del usuario no puede ser vacío");
            }
            await db.InsertUsuario(usuario);

            return Created("Creado", true);
        }


        [Route("UpdateUsuario/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario, string id)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (usuario.Name == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre del usuario no puede ser vacío");
            }
            usuario.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateUsuario(usuario);

            return Created("Creado", true);
        }


        [Route("DeleteUsuario/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario(string id)
        {
            await db.DeleteUsuario(id);
            return NoContent();
        }
    }
}
