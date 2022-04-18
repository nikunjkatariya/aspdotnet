namespace MinimalApiContainer
{
    public class Port
    {
        public int Id { get; set; }
        public string? PortName { get; set; }
        public string? PortLocation { get; set; }
        public string? ContainerId { get; set; }
        public string? ContainerType { get; set; }
        public string? ContainerDetails { get; set; }
        public DateTime LastUpdate { get; set; }=DateTime.Today;
    }
}
