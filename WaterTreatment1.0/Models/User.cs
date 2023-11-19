using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WaterTreatment1._0.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonElement("username")]
        public string Username { get; set; } = String.Empty;
        [BsonElement("password")]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }
}
