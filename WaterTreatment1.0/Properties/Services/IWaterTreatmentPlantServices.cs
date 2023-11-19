namespace WaterTreatment1._0.Services
{
    public interface IWaterTreatmentPlantServices
    {
        List<WaterTreatmentPlantModel> Get();
        WaterTreatmentPlantModel Get(string id);
        WaterTreatmentPlantModel Create(WaterTreatmentPlantModel user);

        void Update(string id, WaterTreatmentPlantModel user);

        void Remove(string id);
    }
}
