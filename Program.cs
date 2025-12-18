using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi;
using WinterEquipmentRentalApi.Repostitory.Abstraction;
using WinterEquipmentRentalApi.Repostitory.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<RentDbContext>(x => 
    x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

builder.Services.AddScoped<IClientRepostitory, ClientRepository>();
builder.Services.AddScoped<IRentalItemRepository, RentalItemRepostitory>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

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

