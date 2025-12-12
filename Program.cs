using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentDbContext>(x => 
    x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var context = services.GetRequiredService<RentDbContext>();
await DbInitializer.SeedData(context);

app.Run();

