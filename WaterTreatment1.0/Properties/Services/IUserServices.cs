using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public interface IUserServices
    {
        List<UserModel> Get();
        UserModel Get(string id);

        UserModel Create(UserModel user);

        void Update(string id, UserModel user);

        void Remove(string id);
    }
}
