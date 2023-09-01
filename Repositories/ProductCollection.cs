using MongoDB.Bson;
using MongoDB.Driver;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public class ProductCollection : IProductoCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Producto> Collection;

        public ProductCollection()
        {
            Collection = _repository.db.GetCollection<Producto>("productos");
        }

        public async Task DeleteProducto(string id)
        {
            var filter = Builders<Producto>.Filter.Eq(d => d.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Producto>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Producto> GetProductoById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id)} }).Result.FirstAsync();
        }

        public async Task InsertProducto(Producto product)
        {
            await Collection.InsertOneAsync(product);
        }

        public async Task UpdateProducto(Producto product)
        {
            var filter = Builders<Producto>.Filter.Eq(d => d.Id, product.Id);
            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}
