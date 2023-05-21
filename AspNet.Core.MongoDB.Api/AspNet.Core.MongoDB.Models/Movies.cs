using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.Metrics;

namespace AspNet.Core.MongoDB.Models
{
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? plot { get; set; }
        public List<string>? genres { get; set; } = null;
        public int runtime { get; set; }
        public List<string> cast { get; set; }
        public int num_mflix_comments { get; set; }
        public string title { get; set; }
        public string fullplot { get; set; }
        public List<string> countries { get; set; }
        //TODO: no se puede deserializar DateTime error
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime released { get; set; }
        public List<string> directors { get; set; }
        public string rated { get; set; }
        public Awards awards { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime lastupdated { get; set; }
        public int year { get; set; }
        public Imdb imdb { get; set; }
        public string type { get; set; }
        public Tomatoes tomatoes { get; set; }
    }

    public class Awards
    {
        public int wins { get; set; }
        public int nominations { get; set; }
        public string text { get; set; }
    }

    public class Imdb
    {
        public int rating { get; set; }
        public int votes { get; set; }
        public int id { get; set; }
    }

    public class Tomatoes
    {
        public Viewer viewer { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime lastUpdated { get; set; }
    }

    public class Viewer
    {
        public int rating { get; set; }
        public int numReviews { get; set; }
        public int meter { get; set; }
    }
}