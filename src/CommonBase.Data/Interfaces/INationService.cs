using CommonBase.Data.Entities;

namespace CommonBase.Data.Interfaces
{
  public interface INationService
  {
    Task CreateAsync(Nation newNation);
    Task<List<Nation>> GetAsync();
    Task<Nation?> GetAsync(Guid id);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(Guid id, Nation updatedNation);
  }
}
