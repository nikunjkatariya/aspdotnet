using paymentGatewayWebAPI.CosmosServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ICosmosDbService>(InitializeCosmosClientInstanceAsync(builder.Configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
{
    var databaseName = configurationSection["Database"];
    var containerName = configurationSection["ContainerName"];
    var account = configurationSection["Account"];
    var key = configurationSection["Key"];

    var client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
    var database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/transactionId");

    var cosmosDbService = new CosmosDbService(client, databaseName, containerName);
    return cosmosDbService;
}