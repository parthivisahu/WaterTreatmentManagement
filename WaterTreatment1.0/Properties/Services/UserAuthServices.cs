using MongoDB.Driver;
using WaterTreatment1._0.Services;
using WaterTreatment1._0;
using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public class UserAuthServices : IUserAuthServices
    {
        private readonly IMongoCollection<User> _users;

        public UserAuthServices(IUserAuthSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.MongoDBCollectionName);
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void Update(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }
    }
}