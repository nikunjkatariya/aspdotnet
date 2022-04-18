using Newtonsoft.Json;

namespace CosmosDBContainerWebAPI.Models
{
    public class ContainerData
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string ContainerCode { get; set; }
        [JsonProperty(PropertyName = "location")]
        public string ContainerLocation { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int ContainerHeight { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int ContainerWidth { get; set; }
    }
}
