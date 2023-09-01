using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Controllers
{
    [Route("api/Categoria")]
    [ApiController]
    public class CategoriaController : Controller
    {

            public ICategoriaCollection db = new CategoriaCollection();

            [Route("getAllCategory")]
            [HttpGet]
            public async Task<IActionResult> GetAllCategorys()
            {
                return Ok(await db.GetAllCategoria());
            }


            [Route("getCategoryById/{id}")]
            [HttpGet]
            public async Task<IActionResult> GetCategoryById(string id)
            {
                return Ok(await db.GetCategoriaById(id));
            }

            [Route("createCategory")]
            [HttpPost]
            public async Task<IActionResult> CreateCategory([FromBody] Categoria categoria)
            {
                if (categoria == null)
                {
                    return BadRequest();
                }

                if (categoria.Name == string.Empty)
                {
                    ModelState.AddModelError("Nombre", "El nombre del categoria no puede ser vacío");
                }
                await db.InsertCategoria(categoria);

                return Created("Creado", true);
            }

            [Route("UpdateCategory/{id}")]
            [HttpPut]
            public async Task<IActionResult> UpdateCategory([FromBody] Categoria categoria, string id)
            {
                if (categoria == null)
                {
                    return BadRequest();
                }

                if (categoria.Name == string.Empty)
                {
                    ModelState.AddModelError("Nombre", "El nombre del Categoryo no puede ser vacío");
                }
            categoria.Id = new MongoDB.Bson.ObjectId(id);
                await db.InsertCategoria(categoria);

                return Created("Creado", true);
            }

            [Route("DeleteCategory/{id}")]
            [HttpDelete]
            public async Task<IActionResult> DeleteCategory(string id)
            {
                await db.DeleteCategoria(id);
                return NoContent();
            }
        }
    
}
