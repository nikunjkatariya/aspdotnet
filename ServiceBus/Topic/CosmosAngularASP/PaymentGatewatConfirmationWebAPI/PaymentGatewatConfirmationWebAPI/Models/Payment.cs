using Newtonsoft.Json;

namespace PaymentGatewatConfirmationWebAPI.Models
{
    public class Payment
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "transactionId")]
        public string? TransactionId { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
        [JsonProperty(PropertyName = "bankName")]
        public string BankName { get; set; }
        [JsonProperty(PropertyName = "cardNumber")]
        public string CardNumber { get; set; }
        [JsonProperty(PropertyName = "validMonth")]
        public int ValidMonth { get; set; }
        [JsonProperty(PropertyName = "validYear")]
        public int ValidYear { get; set; }
        [JsonProperty(PropertyName = "cardHolder")]
        public string CardHolder { get; set; }
        [JsonProperty(PropertyName = "cvv")]
        public string CVV { get; set; }
    }
}
