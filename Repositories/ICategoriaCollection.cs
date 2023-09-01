using PruebaTecnica.Models;
using System.Net.Http.Headers;

namespace PruebaTecnica.Repositories
{
    public interface ICategoriaCollection
    {
        Task InsertCategoria(Categoria product);
        Task UpdateCategoria(Categoria product);
        Task DeleteCategoria(string id);
        Task<List<Categoria>> GetAllCategoria();
        Task<Categoria> GetCategoriaById(string id);
    }
}
