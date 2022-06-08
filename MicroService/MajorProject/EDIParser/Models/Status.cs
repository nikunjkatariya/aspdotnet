using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class Status
    {
        [JsonProperty(PropertyName = "vesselCode")]
        public string VesselCode { get; set; } = "";
        //[JsonProperty(PropertyName = "countryCode")]
        //public string CountryCode { get; set; } = "";
        //[JsonProperty(PropertyName = "dateOne")]
        //public string DateOne { get; set; } = "";
        //[JsonProperty(PropertyName = "dateTwo")]
        //public string DateTwo { get; set; } = "";
        //[JsonProperty(PropertyName = "dateThree")]
        //public string DateThree { get; set; } = "";
        //[JsonProperty(PropertyName = "ladingQuantity")]
        //public string LadingQuantity { get; set; } = "";
        [JsonProperty(PropertyName = "weight")]
        public string Weight { get; set; } = "";
        [JsonProperty(PropertyName = "weightQualifier")]
        public string WeightQualifier { get; set; } = "";
        [JsonProperty(PropertyName = "flightNumber")]
        public string FlightNumber { get; set; } = "";
        //[JsonProperty(PropertyName = "referenceIdQualifier")]
        //public string ReferenceIdQualifier { get; set; } = "";
        //[JsonProperty(PropertyName = "referenceId")]
        //public string ReferenceId { get; set; } = "";
        [JsonProperty(PropertyName = "vesselCodeQualifier")]
        public string VesselCodeQualifier { get; set; } = "";
        [JsonProperty(PropertyName = "vesselName")]
        public string VesselName { get; set; } = "";
        //[JsonProperty(PropertyName = "Volume")]
        //public string Volume { get; set; } = "";
        //[JsonProperty(PropertyName = "volumeUnitQualifier")]
        //public string VolumeUnitQualifier { get; set; } = "";
        [JsonProperty(PropertyName = "weightUnitCode")]
        public string WeightUnitCode { get; set; } = "";
    }
}
