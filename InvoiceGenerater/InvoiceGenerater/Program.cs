using Microsoft.EntityFrameworkCore;
using InvoiceGenerater.Data;
using InvoiceGenerater.Validation;
using InvoiceGenerater.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GSTNumberValidation>();
builder.Services.AddScoped<Format>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InvoiceContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("InvoiceContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Invoices}/{action=Index}/{id?}");

app.Run();
