using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AspNet.Core.MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string? name { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string? email { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string? password { get; set; }
    }
}
