using System;
using Microsoft.Build.Experimental.ProjectCache;
using WinterEquipmentRentalApi.Models;

namespace WinterEquipmentRentalApi;

public class DbInitializer
{
    public static async Task SeedData(RentDbContext context)
    {
        if (context.Clients.Any() ||
            context.RentalItems.Any() ||
            context.Rentals.Any()) return;

        var clients = new List<Client>
        {
            new()
            {
                FirstName = "Hazel",
                LastName = "Horne",
                PhoneNumber = "+79496355212"
            },
            new()
            {
                FirstName = "Connie",
                LastName = "Snow",
                PhoneNumber = "+79071101145"
            },
            new()
            {
                FirstName = "Beatriz",
                LastName = "Love",
                PhoneNumber = "+79578048716"
            },
            new()
            {
                FirstName = "Sonny",
                LastName = "Hunter",
                PhoneNumber = "+79496355212"
            },
            new()
            {
                FirstName = "Marcia",
                LastName = "Jimenez",
                PhoneNumber = "+79869177093"
            },
            new()
            {
                FirstName = "Corina",
                LastName = "Collins",
                PhoneNumber = "+79828594921"
            },
            new()
            {
                FirstName = "Wilton",
                LastName = "Powell",
                PhoneNumber = "+79268503602"
            },
            new()
            {
                FirstName = "Waylon",
                LastName = "Marsh",
                PhoneNumber = "+79045814258"
            },
        };
        var rentalItems = new List<RentalItem>
        {
            new()
            {
                Name = "Горные лыжи Atomic Redster",
                IsAvailable = true,
                Price = 2500m
            },
            new() {
                Name = "Горные лыжи Salomon X-Drive",
                IsAvailable = true,
                Price = 2300m
            },
            new() {
                Name = "Сноуборд Burton Custom",
                IsAvailable = true,
                Price = 2700m
            },
            new() {
                Name = "Сноуборд GNU Riders Choice",
                IsAvailable = true,
                Price = 2600m
            },
            new() {
                Name = "Лыжные ботинки Fischer RC Pro",
                IsAvailable = true,
                Price = 800m
            },
            new() {
                Name = "Сноубордические ботинки ThirtyTwo Lashed",
                IsAvailable = true,
                Price = 900m
            },
            new() {
                Name = "Шлем горнолыжный Smith Holt",
                IsAvailable = true,
                Price = 400m
            },
            new() {
                Name = "Горнолыжные палки Leki Speed S",
                IsAvailable = true,
                Price = 300m
            }
        };
        var rentals = new List<Rental>
        {
            new() {
                RentHours = 4,
                Cost = 1000m,
                ClientID = clients[0].Id,
                Client = clients[0],
                RentalItems =
                {
                    rentalItems[0]
                }
            },
            new() {
                RentHours = 2,
                Cost = 600m,
                ClientID = clients[1].Id,
                Client = clients[1],
                RentalItems =
                {
                    rentalItems[2] 
                }
            },
            new() {
                RentHours = 6,
                Cost = 1500m,
                ClientID = clients[2].Id,
                Client = clients[2],
                RentalItems =
                {
                    rentalItems[3], 
                    rentalItems[6]  
                }
            },
            new() {
                RentHours = 1,
                Cost = 300m,
                ClientID = clients[3].Id,
                Client = clients[3],
                RentalItems =
                {
                    rentalItems[7] 
                }
            },
            new() {
                RentHours = 5,
                Cost = 2000m,
                ClientID = clients[4].Id,
                Client = clients[4],
                RentalItems =
                {
                    rentalItems[1], 
                    rentalItems[4]  
                }
            }
        };

        context.Clients.AddRange(clients);
        context.RentalItems.AddRange(rentalItems);
        context.Rentals.AddRange(rentals);

        await context.SaveChangesAsync();
    }
}
