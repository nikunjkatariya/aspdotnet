using Microsoft.EntityFrameworkCore;
using MinimalAPIAshish.Models;
using MinimalAPIAshish.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDbString"));
});

builder.Services.AddScoped<IStudentService,StudentService>();
// Add services to the container.

builder.Services.AddControllers();
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
/*app.MapGet("/students",async(IStudentService studentService)option.);*/
app.UseAuthorization();

app.MapControllers();

app.Run();
