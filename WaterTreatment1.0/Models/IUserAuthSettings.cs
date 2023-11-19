namespace WaterTreatment1._0.Models
{
    public interface IUserAuthSettings
    {
        string MongoDBCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
