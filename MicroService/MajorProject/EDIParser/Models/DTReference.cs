using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class DTReference
    {
        [JsonProperty(PropertyName = "qualifier")]
        public string Qualifier { get; set; } = "";
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; } = "";
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; } = "";
        [JsonProperty(PropertyName = "timeCode")]
        public string TimeCode { get; set; } = "";
        [JsonProperty(PropertyName = "periodFormatQualifier")]
        public string PeriodFormatQualifier { get; set; } = "";
        [JsonProperty(PropertyName = "dTPeriod")]
        public string DTPeriod { get; set; } = "";
    }
}
