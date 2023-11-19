using MongoDB.Driver;
using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public class TreatmentStatsServices : ITreatmentStatsServices
    {


        private readonly IMongoCollection<TreatmentStatsModel> _stats;

        public TreatmentStatsServices(ITreatmentStatsSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _stats = database.GetCollection<TreatmentStatsModel>(settings.MongoDBCollectionName);
        }

        public TreatmentStatsModel Create(TreatmentStatsModel stats)
        {
            _stats.InsertOne(stats);
            return stats;
        }

        public List<TreatmentStatsModel> Get()
        {
            return _stats.Find(stats => true).ToList();
        }

        public TreatmentStatsModel Get(string id)
        {
            return _stats.Find(stats => stats.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _stats.DeleteOne(plant => plant.Id == id);
        }

        public void Update(string id, TreatmentStatsModel plant)
        {
            _stats.ReplaceOne(plants => plants.Id == id, plant);
        }
    }
}
