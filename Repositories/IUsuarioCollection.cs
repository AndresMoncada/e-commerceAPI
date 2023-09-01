using PruebaTecnica.Models;
using System.Net.Http.Headers;

namespace PruebaTecnica.Repositories
{
    public interface IUsuarioCollection
    {
        Task InsertUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(string id);
        Task<List<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(string id);
        Task<Usuario> ValidateLogin(string email, string password);
    }
}
