using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WaterTreatment1._0.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("username")]
        public string Username { get; set; } = String.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;

        [BsonElement("role")]
        public string Role { get; set; } = String.Empty;

    }

    public class UsersService
    {
        private readonly IMongoCollection<UserModel> _users;

        public UsersService(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _users = database.GetCollection<UserModel>(collectionName);
        }

        public void InsertUser(UserModel user)
        {
            _users.InsertOne(user);
        }
    }
}