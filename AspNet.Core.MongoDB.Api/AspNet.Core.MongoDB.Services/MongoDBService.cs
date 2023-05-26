using AspNet.Core.MongoDB.Models;

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using AspNet.CoreMongoDB.DataLayer;

namespace AspNet.Core.MongoDB.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Users> _moviesCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
           MongoClient client =  new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _moviesCollection = database.GetCollection<Users>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<List<Users>> GetMoviesAsync() { 
            var result = await _moviesCollection.Find(new BsonDocument()).ToListAsync();
            return result;
        }  
        public async Task CreateMovieAsync(Users user) {
            await _moviesCollection.InsertOneAsync(user);
        }

        public async Task DeleteAsync(string movieId) {
            FilterDefinition<Users> filter = Builders<Users>.Filter.Eq("Id", movieId);
            await _moviesCollection.DeleteOneAsync(filter);
        }
    }
}