using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiMongoDb.models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [Required(ErrorMessage = "O nome do Cliente é obrigatório")]
        public string? nome { get; set; }
        public DateTime datanascimento { get; set; }
        [Range(11111111,99999999999,ErrorMessage="O numero de telefone deve ter até 10 caracteres")]
        public double celular { get; set; }
        public string? documento { get; set; }
    }
}
