using AspNet.Core.MongoDB.Models;

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using AspNet.CoreMongoDB.DataLayer;

namespace AspNet.Core.MongoDB.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Movies> _moviesCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
           MongoClient client =  new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _moviesCollection = database.GetCollection<Movies>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Movies>> GetMoviesAsync() =>  await _moviesCollection.Find(new BsonDocument()).ToListAsync();
        public async Task CreateMovieAsync(Movies movies) {
            await _moviesCollection.InsertOneAsync(movies);
        }

        public async Task DeleteAsync(string movieId) { 
            await _moviesCollection.DeleteOneAsync(movieId);
        }
    }
}