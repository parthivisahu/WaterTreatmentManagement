using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WaterTreatment1._0.Models
{
    public class TreatmentStatsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("plantId")]
        public string PlantId { get; set; } = String.Empty;

        [BsonElement("coagulation")]
        public double Coagulation { get; set; }

        [BsonElement("flocculation")]
        public double Flocculation { get; set; }

        [BsonElement("sedimentation")]
        public double Sedimentation { get; set; }

        [BsonElement("filtration")]
        public double Filtration { get; set; } 

        [BsonElement("disinfection")]
        public double Disinfection { get; set; }  

    }
      
}