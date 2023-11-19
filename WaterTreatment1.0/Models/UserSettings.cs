namespace WaterTreatment1._0.Models
{
    public class UserSettings : IUserSettings
    {
        public string MongoDBCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
