using Microsoft.EntityFrameworkCore;

namespace MinimalApiContainer
{
    public class PortService:IPortService
    {
        private readonly PortContext _context;

        public PortService(PortContext context)
        {
            _context=context;
        }
        //Get
        public async Task<IResult> GetPorts()
        {
            return Results.Ok(await _context.Ports.ToListAsync());
        }
        //Get{id}
        public async Task<IResult> GetPort(int id)
        {
            var article = await _context.Ports.FindAsync(id);
            return article != null ? Results.Ok(article) : Results.NotFound();
        }
        //Post
        public async Task<IResult> CreatePort(PortRequest port)
        {
            var createarticle = _context.Ports.Add(new Port
            {
                PortName=port.PortName??String.Empty,
                PortLocation=port.PortLocation??String.Empty,
                ContainerId=port.ContainerId??String.Empty,
                ContainerType=port.ContainerType??String.Empty,
                ContainerDetails=port.ContainerDetails??String.Empty,
                LastUpdate=port.LastUpdate
            });
            await _context.SaveChangesAsync();
            return Results.Created($"/port/" +
                $"{createarticle.Entity.Id}", createarticle.Entity);
        }
        //Put
        public async Task<IResult> UpdatePort(int id, PortRequest port)
        {
            var portToUpdate = await _context.Ports.FindAsync(id);
            if (portToUpdate == null)
            {
                return Results.NotFound();
            }
            portToUpdate.PortName = port.PortName ?? String.Empty;
            portToUpdate.PortLocation = port.PortLocation ?? String.Empty;
            portToUpdate.ContainerId = port.ContainerId ?? String.Empty;
            portToUpdate.ContainerType = port.ContainerType ?? String.Empty;
            portToUpdate.ContainerDetails = port.ContainerDetails ?? String.Empty;
            portToUpdate.LastUpdate = port.LastUpdate;
            await _context.SaveChangesAsync();
            return Results.Ok(portToUpdate);
        }
        //Delete
        public async Task<IResult> DeletePort(int id)
        {
            var article = await _context.Ports.FindAsync(id);

            if (article == null)
            {
                return Results.NotFound();
            }

            _context.Ports.Remove(article);
            await _context.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}
