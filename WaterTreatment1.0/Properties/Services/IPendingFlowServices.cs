using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public interface IPendingFlowServices
    {
        List<PendingFlowModel> Get();
        PendingFlowModel Get(string id);

        PendingFlowModel Create(PendingFlowModel user);

        void Update(string id, PendingFlowModel user);

        void Remove(string id);
    }
}
