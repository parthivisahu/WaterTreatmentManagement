namespace WaterTreatment1._0.Models
{
    public interface IWaterTreatmentPlantSettings
    {
        string MongoDBCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
