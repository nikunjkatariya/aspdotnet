using Newtonsoft.Json;

namespace EDIParser.Models
{
    public class PortOrTerminal
    {
        [JsonProperty(PropertyName = "functionCode")]
        public string FunctionCode { get; set; } = "";
        [JsonProperty(PropertyName = "locationQualifier")]
        public string LocationQualifier { get; set; } = "";
        [JsonProperty(PropertyName = "locationIdentifier")]
        public string LocationIdentifier { get; set; } = "";
        [JsonProperty(PropertyName = "portNumber")]
        public string PortName { get; set; } = "";
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; } = "";
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; } = "";
        [JsonProperty(PropertyName = "pierName")]
        public string PierName { get; set; } = "";
        [JsonProperty(PropertyName = "stateCode")]
        public string StateCode { get; set; } = "";
    }
}
