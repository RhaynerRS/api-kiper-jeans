using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiMongoDb.models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? name { get; set; }
        public float preco { get; set; }
        public int quantidade { get; set; }
        public string categoria { get; set; } = "";
        public string[]? tamanhos { get; set; }
    }
}
