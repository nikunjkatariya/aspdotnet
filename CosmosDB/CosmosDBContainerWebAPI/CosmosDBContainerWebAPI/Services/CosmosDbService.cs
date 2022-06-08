using CosmosDBContainerWebAPI.Models;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace CosmosDBContainerWebAPI.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;
        public CosmosDbService(CosmosClient cosmosDbClient,string databaseName, string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName,containerName);
        }

        public async Task AddAsync(ContainerData containerData)
        {
            await _container.CreateItemAsync(containerData, new PartitionKey(containerData.Id));
        }

        public async Task UpdateAsync(string id, ContainerData data)
        {
            await _container.UpsertItemAsync(data, new PartitionKey(id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<ContainerData>(id, new PartitionKey(id));
        }

        public async Task<ContainerData> GetAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<ContainerData>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ContainerData>> GetMultipleAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<ContainerData>(new QueryDefinition(queryString));
            var results = new List<ContainerData>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
    }
}
