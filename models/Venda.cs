using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiMongoDb.models
{
    public class Venda
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime data { get; set; }
        public string? formaDePagamento { get; set; }
        public float valor { get; set; }
        public ItemVenda[]? produtos { get; set; }
        public int? __v {get; set;}
    }
}
