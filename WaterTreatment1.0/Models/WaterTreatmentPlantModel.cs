using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class WaterTreatmentPlantModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    [BsonElement("name")]
    public string Name { get; set; } = String.Empty;
    [BsonElement("location")]
    public string Location { get; set; } = String.Empty;
    [BsonElement("gallonsPresent")]
    public double GallonsPresent { get; set; }
    [BsonElement("temperature")]
    public double Temperature { get; set; }
}
