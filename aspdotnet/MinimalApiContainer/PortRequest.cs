namespace MinimalApiContainer
{
    public record PortRequest(string? PortName, string? PortLocation,
        string? ContainerId, string? ContainerType, string? ContainerDetails,
        DateTime LastUpdate);
}
