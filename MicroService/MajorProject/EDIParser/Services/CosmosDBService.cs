using EDIParser.Models;
using Microsoft.Azure.Cosmos;

namespace EDIParser.Services
{
    public class CosmosDBService : ICosmosDBService
    {
        private Container _container;
        public CosmosDBService(CosmosClient cosmosDbClient, string databaseName, string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }
        //ADD ParserData
        public async Task AddAsync(Watchlist data)
        {
            await _container.CreateItemAsync(data, new PartitionKey(data.ContainerId));
        }
        //GET Data
        public async Task<Watchlist> GetAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Watchlist>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                return null;
            }
        }
        //Update ParserData
        public async Task UpdateAsync(string id, Watchlist data)
        {
            await _container.UpsertItemAsync(data, new PartitionKey(id));
        }
    }
}
