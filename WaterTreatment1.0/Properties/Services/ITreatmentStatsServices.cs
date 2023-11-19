using WaterTreatment1._0.Models;

namespace WaterTreatment1._0.Services
{
    public interface ITreatmentStatsServices
    {
        List<TreatmentStatsModel> Get();
        TreatmentStatsModel Get(string id);

        TreatmentStatsModel Create(TreatmentStatsModel stats);

        void Update(string id, TreatmentStatsModel stats);

        void Remove(string id);
    }
}
