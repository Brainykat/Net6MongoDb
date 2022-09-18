using CommonBase.Data.Entities;

namespace CommonBase.Data.Interfaces
{
  public interface INationService
  {
    Task CreateAsync(Nation newNation);
    Task<List<Nation>> GetAsync();
    Task<Nation?> GetAsync(string id);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, Nation updatedNation);
  }
}
