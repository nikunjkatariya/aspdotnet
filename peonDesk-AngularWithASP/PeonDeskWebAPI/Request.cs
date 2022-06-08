namespace PeonDeskWebAPI
{
    public class Request
    {
        public int Id { get; set; }
        public string? SenderId { get; set; }
        public string? RecieverId { get; set; }
        public string? DocumentDetails { get; set; }
        public DateTime TakenDate { get; set; }
        public bool RequiestStatus { get; set; }
        public string? peonId { get; set; }=String.Empty;
        public bool DeliveryStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
