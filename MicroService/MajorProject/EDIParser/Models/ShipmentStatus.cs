using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class ShipmentStatus
    {
        [JsonProperty(PropertyName = "shipmentStatusCode")]
        public string ShipmentStatusCode { get; set; } = "";
        //[JsonProperty(PropertyName = "statusReasonCode")]
        //public string StatusReasonCode { get; set; } = "";
        //[JsonProperty(PropertyName = "dispositionCode")]
        //public string DispositionCode { get; set; } = "";
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; } = "";
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; } = "";
    }
}
