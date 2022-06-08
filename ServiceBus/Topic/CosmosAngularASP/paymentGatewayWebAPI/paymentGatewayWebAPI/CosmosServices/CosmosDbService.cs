using Microsoft.Azure.Cosmos;
using paymentGatewayWebAPI.Models;

namespace paymentGatewayWebAPI.CosmosServices
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container container;
        
        public CosmosDbService(CosmosClient cosmosDbClient, string databaseName, string containerName)
        {
            container = cosmosDbClient.GetContainer(databaseName, containerName);
        }
        
        public async Task AddPayment(Payment payment)
        {
            await container.CreateItemAsync(payment,new PartitionKey(payment.TransactionId));
        }

        public async Task<IEnumerable<Payment>> GetPayments(string queryString)
        {
            var query = container.GetItemQueryIterator<Payment>(new QueryDefinition(queryString));
            var results = new List<Payment>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }
    }
}
