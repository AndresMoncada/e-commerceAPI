using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PruebaTecnica.Models
{
    public class Usuario
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
