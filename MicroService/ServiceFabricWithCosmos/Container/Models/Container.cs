using Newtonsoft.Json;

namespace Container.Models
{
    public class Container
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
