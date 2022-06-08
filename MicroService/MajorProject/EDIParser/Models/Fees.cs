using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class Fees
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; } = "";
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; } = "";
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; } = "";
    }
}
