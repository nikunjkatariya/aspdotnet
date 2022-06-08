using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class Segment
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; } = "";
        //[JsonProperty(PropertyName = "inquiryRequestNumber")]
        //public string InquiryRequestNumber { get; set; } = "";
        [JsonProperty(PropertyName = "shipmentStatusCode")]
        public string ShipmentStatusCode { get; set; } = "";
        [JsonProperty(PropertyName = "releaseDate")]
        public string ReleaseDate { get; set; } = "";
        [JsonProperty(PropertyName = "releaseTime")]
        public string ReleaseTime { get; set; } = "";
        //[JsonProperty(PropertyName = "statusLocation")]
        //public string StatusLocation { get; set; } = "";
        [JsonProperty(PropertyName = "equipmentInitial")]
        public string EquipmentInitial { get; set; } = "";
        [JsonProperty(PropertyName = "equipmentNumber")]
        public string EquipmentNumber { get; set; } = "";
        [JsonProperty(PropertyName = "equipmentStatusCode")]
        public string EquipmentStatusCode { get; set; } = "";
        [JsonProperty(PropertyName = "equipmentType")]
        public string EquipmentType { get; set; } = "";
        //[JsonProperty(PropertyName = "locationIdentifier")]
        //public string LocationIdentifier { get; set; } = "";
        //[JsonProperty(PropertyName = "locationQualifier")]
        //public string LocationQualifier { get; set; } = "";
        [JsonProperty(PropertyName = "equipmentDigit")]
        public string EquipmentDigit { get; set; } = "";
    }
}
