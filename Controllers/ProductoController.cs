using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : Controller
    {
        public IProductoCollection db = new ProductCollection();

        [Route("getAllProduct")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() {
            return Ok(await db.GetAllProducts());
        }


        [Route("getProductById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(string id)
        {
            return Ok(await db.GetProductoById(id));
        }

        [Route("createProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Producto producto)
        {
            if (producto == null) {
                return BadRequest();
            }

            if (producto.Name == string.Empty) {
                ModelState.AddModelError("Nombre", "El nombre del producto no puede ser vacío");
            }
            await db.InsertProducto(producto);

            return Created("Creado", true);
        }


        [Route("UpdateProduct/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Producto producto, string id)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            if (producto.Name == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre del producto no puede ser vacío");
            }
            producto.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProducto(producto);

            return Created("Creado", true);
        }


        [Route("DeleteProduct/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProducto(id);
            return NoContent();
        }
    }

}
