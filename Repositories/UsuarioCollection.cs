using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public class UsuarioCollection : IUsuarioCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Usuario> Collection;

        public UsuarioCollection()
        {
            Collection = _repository.db.GetCollection<Usuario>("usuarios");
        }

        public async Task DeleteUsuario(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(d => d.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task<Usuario> ValidateLogin(string email, string password)
        {
            return await Collection.FindAsync(u => u.Email == email && u.Password == password).Result.FirstAsync();
        }
        public async Task InsertUsuario(Usuario usuario)
        {
            await Collection.InsertOneAsync(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(d => d.Id, usuario.Id);
            await Collection.ReplaceOneAsync(filter, usuario);
        }
    }
}
