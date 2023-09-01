using PruebaTecnica.Models;
using System.Net.Http.Headers;

namespace PruebaTecnica.Repositories
{
    public interface IProductoCollection
    {
        Task InsertProducto(Producto product);
        Task UpdateProducto(Producto product);
        Task DeleteProducto(string id);
        Task<List<Producto>> GetAllProducts();
        Task<Producto> GetProductoById(string id);
    }
}
