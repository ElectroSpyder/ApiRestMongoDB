using MongoDB.Bson.Serialization.Attributes;

namespace AspNet.Core.MongoDB.Models
{
    public class Movies
    {
        [BsonId]
        public int Id { get; set; }
        public string? plot { get; set; } = null;
    }
}