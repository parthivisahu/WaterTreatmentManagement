using MongoDB.Driver;
using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public class WaterTreatmentPlantServices: IWaterTreatmentPlantServices
    {
      

        private readonly IMongoCollection<WaterTreatmentPlantModel> _plants;

            public WaterTreatmentPlantServices(IWaterTreatmentPlantSettings settings, IMongoClient mongoClient)
            {
                var database = mongoClient.GetDatabase(settings.DatabaseName);
                _plants = database.GetCollection<WaterTreatmentPlantModel>(settings.MongoDBCollectionName);
            }

            public WaterTreatmentPlantModel Create(WaterTreatmentPlantModel plants)
            {
                _plants.InsertOne(plants);
                return plants;
            }

            public List<WaterTreatmentPlantModel> Get()
            {
                return _plants.Find(plants => true).ToList();
            }

            public WaterTreatmentPlantModel Get(string id)
            {
                return _plants.Find(plant => plant.Id == id).FirstOrDefault();
            }

            public void Remove(string id)
            {
                _plants.DeleteOne(plant => plant.Id == id);
            }

            public void Update(string id, WaterTreatmentPlantModel plant)
            {
                _plants.ReplaceOne(plants => plants.Id == id, plant);
            }
        }
    }
