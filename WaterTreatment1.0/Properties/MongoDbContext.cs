using MongoDB.Driver;
using WaterTreatment1._0.Models;

namespace WaterTreatment1._0
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<UserModel> Users => _database.GetCollection<UserModel>("Users");
        public IMongoCollection<WaterTreatmentPlantModel> WaterTreatmentPlants => _database.GetCollection<WaterTreatmentPlantModel>("WaterTreatmentPlants");
        public IMongoCollection<PendingFlowModel> PendingFlow => _database.GetCollection<PendingFlowModel>("PendingFlow");

    }

}
