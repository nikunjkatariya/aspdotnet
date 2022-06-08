namespace MinimalApiContainer
{
    public interface IPortService
    {
        Task<IResult> GetPorts();
        Task<IResult> GetPort(int id);
        Task<IResult> CreatePort(PortRequest port);
        Task<IResult> UpdatePort(int id,PortRequest port);
        Task<IResult> DeletePort(int id);
    }
}
