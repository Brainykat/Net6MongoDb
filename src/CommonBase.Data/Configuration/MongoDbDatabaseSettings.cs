namespace CommonBase.Data.Configuration
{
  public class MongoDbDatabaseSettings
  {
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string NationsCollectionName { get; set; } = null!;
    public string AccountsCollectionName { get; set; } = null!;
  }
}
