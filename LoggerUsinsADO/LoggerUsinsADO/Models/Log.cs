namespace LoggerUsinsADO.Models
{
    public class Log
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
    }
}
