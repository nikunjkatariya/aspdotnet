using Microsoft.EntityFrameworkCore;
using MinimalApiContainer;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PortContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("PortContext")));
builder.Services.AddScoped<IPortService, PortService>();
var app = builder.Build();

//Get Ports
app.MapGet("/port",async(IPortService portService)=>await portService.GetPorts());
//Get Port By Id
app.MapGet("/port/{id}", async (int id,IPortService portService) => await portService.GetPort(id));
//Post Port
app.MapPost("/port", async (PortRequest portRequest,IPortService portService) => await portService.CreatePort(portRequest));
//Update Port
app.MapPut("/port/{id}", async (int id,PortRequest portRequest,IPortService portService) => await portService.UpdatePort(id,portRequest));
//Delete Port
app.MapDelete("/port/{id}", async (int id,IPortService portService) => await portService.DeletePort(id));

app.MapGet("/", () => "Hello Port Users!");
app.Urls.Add("http://localhost:3000");
app.Run();
