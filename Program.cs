using Microsoft.EntityFrameworkCore;
using WinterEquipmentRentalApi;
using WinterEquipmentRentalApi.Middleware;
using WinterEquipmentRentalApi.Repostitory.Abstraction;
using WinterEquipmentRentalApi.Repostitory.Implementation;
using WinterEquipmentRentalApi.Services.Abstraction;
using WinterEquipmentRentalApi.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<RentDbContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

// Dependency Injection - repositories
builder.Services.AddScoped<IClientRepostitory, ClientRepository>();
builder.Services.AddScoped<IRentalItemRepository, RentalItemRepostitory>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalReturnRepository, RentalReturnRepository>();

// Dependency Injection - services
builder.Services.AddScoped<IRentalItemService, RentalItemService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IRentalReturnService, RentalReturnService>();

builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);

var app = builder.Build();

app.UseHttpsRedirection();

// Global exception handler middleware (returns structured JSON error responses)
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<RentDbContext>();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during seeding data.");
}

app.Run();

