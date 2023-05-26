using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AspNet.Core.MongoDB.Models
{
    public class CPresupuesto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? IdMongo { get; set; }
        [BsonElement("Id")]
        public int Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string? Mes { get; set; }
        [BsonElement("Año")]
        public int Anio { get; set; }
        [BsonElement("Total Ingreso")]
        public int TotalIngreso { get; set; }
        [BsonElement("Total Erogación")]
        public int TotalErogacion { get; set; }
        public int Neto { get; set; }
    }
}
