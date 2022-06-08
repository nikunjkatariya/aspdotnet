namespace PaymentReceiver.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Sum { get => Amount * ProductQuantity; }
    }
}
