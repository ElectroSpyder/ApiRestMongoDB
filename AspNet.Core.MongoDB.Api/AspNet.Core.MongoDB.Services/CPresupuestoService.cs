using AspNet.Core.MongoDB.Models;
using AspNet.CoreMongoDB.DataLayer;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AspNet.Core.MongoDB.Services
{
    public class CPresupuestoService
    {
        private readonly IMongoCollection<CPresupuesto> _cPresupuestoCollection;
        public CPresupuestoService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _cPresupuestoCollection = database.GetCollection<CPresupuesto>(mongoDBSettings.Value.CollectionName);           
        }
        public async Task<List<CPresupuesto>> GetPresupuestoAsync()
        {
            var result = await _cPresupuestoCollection.Find(new BsonDocument()).ToListAsync();
            return result;
        }
        public async Task CreatePresupuestoAsync(CPresupuesto cPresupuesto)
        {
            await _cPresupuestoCollection.InsertOneAsync(cPresupuesto);
        }

        public async Task DeleteAsync(string presupuestoId)
        {
            FilterDefinition<CPresupuesto> filter = Builders<CPresupuesto>.Filter.Eq("Id", presupuestoId);
            await _cPresupuestoCollection.DeleteOneAsync(filter);
        }
    }
}
