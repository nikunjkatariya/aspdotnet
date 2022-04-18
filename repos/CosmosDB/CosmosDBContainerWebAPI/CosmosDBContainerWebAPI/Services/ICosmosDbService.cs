using CosmosDBContainerWebAPI.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CosmosDBContainerWebAPI.Services
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
