using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WaterTreatment1._0.Models
{
    public class PendingFlowModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.ObjectId)]
        public string SupervisorId { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.ObjectId)]
        public string PlantId { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("Status")]
        public string Status { get; set; } = String.Empty;

        [BsonElement("Details")]
        public string Details { get; set; } = String.Empty;

    }

   
}