using Container.Models;

namespace Container.Services
{
    public class ICosmosDbService
    {
        Task<IEnumerable<Container>> GetMultipleAsync(string query);
        Task<Container> GetAsync(string id);
        Task AddAsync(Container data);
        Task UpdateAsync(string id, Container data);
        Task DeleteAsync(string id);
    }
}
