using CommonBase.Data.Configuration;
using CommonBase.Data.Entities;
using CommonBase.Data.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CommonBase.Data.Services
{
  public class NationService : INationService
  {
    private readonly IMongoCollection<Nation> nationCollection;

    public NationService(
        IOptions<MongoDbDatabaseSettings> bookStoreDatabaseSettings)
    {
      var mongoClient = new MongoClient(
          bookStoreDatabaseSettings.Value.ConnectionString);

      var mongoDatabase = mongoClient.GetDatabase(
          bookStoreDatabaseSettings.Value.DatabaseName);

      nationCollection = mongoDatabase.GetCollection<Nation>(
          bookStoreDatabaseSettings.Value.NationsCollectionName);
    }

    public async Task<List<Nation>> GetAsync() =>
        await nationCollection.Find(_ => true).ToListAsync();

    public async Task<Nation?> GetAsync(Guid id) =>
        await nationCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Nation newNation) =>
        await nationCollection.InsertOneAsync(newNation);

    public async Task UpdateAsync(Guid id, Nation updatedNation) =>
        await nationCollection.ReplaceOneAsync(x => x.Id == id, updatedNation);

    public async Task RemoveAsync(Guid id) =>
        await nationCollection.DeleteOneAsync(x => x.Id == id);
  }
}
