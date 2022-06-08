using Microsoft.Azure.Cosmos;
using PaymentGatewatConfirmationWebAPI.Models;

namespace PaymentGatewatConfirmationWebAPI.Services
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
            await container.CreateItemAsync(payment, new PartitionKey(payment.TransactionId));
        }
    }
}
