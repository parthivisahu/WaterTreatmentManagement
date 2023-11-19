using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public interface IUserAuthServices
    {
        List<User> Get();
        User Get(string id);

        User Create(User user);

        void Update(string id, User user);

        void Remove(string id);
    }
}
