using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class Watchlist
    {
        [JsonProperty(PropertyName = "id")]
        public string ContainerId { get; set; }
        [JsonProperty(PropertyName = "segment")]
        public Segment Segment { get; set; }
        [JsonProperty(PropertyName = "referenceIdentification")]
        public ReferenceIdentification ReferenceIdentification { get; set; }
        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }
        [JsonProperty(PropertyName = "shipmentStatus")]
        public List<ShipmentStatus> ShipmentStatus { get; set; }
        [JsonProperty(PropertyName = "portOrTerminal")]
        public List<PortOrTerminal> PortOrTerminal { get; set; }
        //[JsonProperty(PropertyName = "dTReference")]
        //public DTReference DTReference { get; set; }
    }
}
