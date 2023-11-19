using MongoDB.Driver;
using WaterTreatment1._0.Services;
using WaterTreatment1._0;
using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public class PendingFlowServices : IPendingFlowServices 
    {
        private readonly IMongoCollection<PendingFlowModel> _pending;

        public PendingFlowServices(IPendingFlowSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _pending = database.GetCollection<PendingFlowModel>(settings.MongoDBCollectionName);
        }

        public PendingFlowModel Create(PendingFlowModel pending)
        {
            _pending.InsertOne(pending);
            return pending;
        }

        public List<PendingFlowModel> Get()
        {
            return _pending.Find(pending => true).ToList();
        }

        public PendingFlowModel Get(string id)
        {
            return _pending.Find(pending => pending.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _pending.DeleteOne(pending => pending.Id == id);
        }

        public void Update(string id, PendingFlowModel pending)
        {
            _pending.ReplaceOne(pending => pending.Id == id, pending);
        }
    }
}