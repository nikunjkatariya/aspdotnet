using ContainerDetails.Models;

namespace ContainerDetails.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<ContainerData>> GetMultipleAsync(string query);
        Task<ContainerData> GetAsync(string id);
        Task AddAsync(ContainerData data);
        Task UpdateAsync(string id, ContainerData data);
        Task DeleteAsync(string id);
    }
}
