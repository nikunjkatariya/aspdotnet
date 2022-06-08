namespace PaymentSender.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Amount { get; set; }
    }
}
