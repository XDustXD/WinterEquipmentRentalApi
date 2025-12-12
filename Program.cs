using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentDbContext>(x => 
    x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<RentDbContext>();
    await DbInitializer.SeedData(context);
}
catch(Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during seeding data.");
}

app.Run();

