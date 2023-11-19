using MongoDB.Driver;
using WaterTreatment1._0.Services;
using WaterTreatment1._0;
using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public class UserService : IUserServices
    {
        private readonly IMongoCollection<UserModel> _users;

        public UserService(IUserSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<UserModel>(settings.MongoDBCollectionName);
        }

        public UserModel Create(UserModel user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<UserModel> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public UserModel Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void Update(string id, UserModel user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }
    }
}