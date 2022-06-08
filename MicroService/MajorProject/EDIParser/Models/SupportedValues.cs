using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class SupportedValues
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; } = "";
        [JsonProperty(PropertyName = "referenceId")]
        public string ReferenceId { get; set; } = "";
    }
}
