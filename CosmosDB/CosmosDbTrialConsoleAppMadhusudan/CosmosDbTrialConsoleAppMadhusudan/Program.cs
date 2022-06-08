using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CosmosDbTrialConsoleAppMadhusudan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CosmosConnect cosmos = new CosmosConnect();
            cosmos.CreateDatabaseAsync().Wait();
            cosmos.CreateContainerAsync().Wait();
            cosmos.AddItemsToContainerAsync().Wait();
            cosmos.DisplayItemsAsync().Wait();
            cosmos.UpdateRecord().Wait();
            cosmos.DeleteRecord().Wait();

        }
    }

    public class CosmosConnect
    {
        private static readonly string Endpoint = "https://localhost:8081";
        private static readonly string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private string databaseId = "CountryDB";
        private string PartitionKey = "Continent";
        private string containerId = "Country";

        private CosmosClient cosmosClient;
        private Database database;
        private Container container;

        public CosmosConnect()
        {
            try
            {
                Console.WriteLine("Establishing Connection...");
                this.cosmosClient = new CosmosClient(Endpoint,PrimaryKey);
            }
            catch (CosmosException cosmosException)
            {
                Console.WriteLine($"Cosmos Exception{cosmosException.StatusCode}:{cosmosException}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
        }
        public async Task CreateDatabaseAsync()
        {
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine($"Create Container: {this.databaseId}");
        }

        public async Task CreateContainerAsync()
        {
            this.container = await this.database.CreateContainerIfNotExistsAsync(this.containerId, "/continent");
            Console.WriteLine($"Container: {containerId}");
        }

        public async Task AddItemsToContainerAsync()
        {
            States state = new States
            {
                Id="2",
                State="Gujarat",
                Country="India",
                Continent="Asia"
            };
            try
            {
                ItemResponse<States> country = await this.container.ReadItemAsync<States>(state.Id, new PartitionKey(state.Continent));
                Console.WriteLine("Item is Already in Database Id: {0}",country.Resource.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode ==HttpStatusCode.NotFound)
            {
                ItemResponse<States> country = await this.container.CreateItemAsync<States>(state,new PartitionKey(state.Continent));
                Console.WriteLine($"Record Inserted. ID: {country.Resource.Id}\t Request Unit : {country.RequestCharge}");
            }
        }

        public async Task DisplayItemsAsync()
        {
            var query = "SELECT * FROM c WHERE c.state = 'Gujarat'";
            Console.WriteLine("Running query: {0}",query);
            QueryDefinition queryDefinition = new QueryDefinition(query);
            FeedIterator<States> countryfeed = this.container.GetItemQueryIterator<States>(query);

            List<States> state = new List<States>();
            while (countryfeed.HasMoreResults)
            {
                FeedResponse<States> currentResultSet = await countryfeed.ReadNextAsync();
                foreach (States s in currentResultSet)
                {
                    state.Add(s);
                    Console.WriteLine($"Read {state}\n");
                }
            }
        }

        public async Task UpdateRecord()
        {
            ItemResponse<States> state = await this.container.ReadItemAsync<States>("1",new PartitionKey("Asia"));
            var itemBody = state.Resource;
            itemBody.Country = "America";

            state = await this.container.ReplaceItemAsync<States>(itemBody, itemBody.Id, new PartitionKey(itemBody.Continent));
            Console.WriteLine($"{itemBody.Country}, {itemBody.Id}\n{state.Resource}");
        }

        public async Task DeleteRecord()
        {
            var partitionKey = "Asia";
            var stateId = "2";

            ItemResponse<States> state = await this.container.DeleteItemAsync<States>(stateId, new PartitionKey(partitionKey));
            Console.WriteLine($"Delete User {partitionKey}, {stateId}");
        }
    }

    class States{
        [JsonProperty(PropertyName="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [JsonProperty(PropertyName="continent")]
        public string Continent { get; set; }
    }
}
