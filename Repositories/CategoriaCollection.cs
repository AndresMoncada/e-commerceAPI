using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public class CategoriaCollection : ICategoriaCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Categoria> Collection;

        public CategoriaCollection()
        {
            Collection = _repository.db.GetCollection<Categoria>("categorias");
        }

        public async Task DeleteCategoria(string id)
        {
            var filter = Builders<Categoria>.Filter.Eq(d => d.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Categoria>> GetAllCategoria()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task InsertCategoria(Categoria product)
        {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateCategoria(Categoria product)
        {
            var filter = Builders<Categoria>.Filter.Eq(d => d.Id, product.Id);
            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}
