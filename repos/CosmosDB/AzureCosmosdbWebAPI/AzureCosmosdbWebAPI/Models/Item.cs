using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AzureCosmosdbWebAPI.Models
{
    public class Item
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "isComplete")]
        public string Completed { get; set; }
    }
}
