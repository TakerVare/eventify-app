using EventifyApi.Models.Entities;

namespace EventifyApi.Data.Seeders;

public class LocationSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // If locations already exist, do nothing
        if (context.Locations.Any()) return;

        var locations = new List<Location>
        {
            new Location
            {
                Name = "Grand Conference Hall",
                Address = "123 Innovation Dr, Tech City",
                Capacity = 500,
                ImageUrl = "https://images.unsplash.com/photo-1517457373958-b7bdd4587205?auto=format&fit=crop&q=80",
                IsActive = true
            },
            new Location
            {
                Name = "Community Center Garden",
                Address = "45 Green Way, Suburbia",
                Capacity = 100,
                ImageUrl = "https://images.unsplash.com/photo-1519167758481-83f550bb49b3?auto=format&fit=crop&q=80",
                IsActive = true
            },
            new Location
            {
                Name = "Tech Hub Workspace",
                Address = "789 Digital Ave, Silicon Valley",
                Capacity = 50,
                ImageUrl = "https://images.unsplash.com/photo-1497366216548-37526070297c?auto=format&fit=crop&q=80",
                IsActive = true
            }
        };

        await context.Locations.AddRangeAsync(locations);
        await context.SaveChangesAsync();
    }
}