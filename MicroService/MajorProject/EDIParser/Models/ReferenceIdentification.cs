using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class ReferenceIdentification
    {
        [JsonProperty(PropertyName = "fees")]
        public List<Fees> Fees { get; set; }
        [JsonProperty(PropertyName = "supportedValues")]
        public List<SupportedValues> SupportedValues { get; set; }
    }
}
