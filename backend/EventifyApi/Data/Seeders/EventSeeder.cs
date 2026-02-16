using EventifyApi.Models.Entities;
using EventifyApi.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace EventifyApi.Data.Seeders;

public class EventSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // If events already exist, do nothing
        if (context.Events.Any()) return;

        // 1. Get necessary dependencies (User, Location, Category)
        // We look for the first available user to be the organizer
        var organizer = await context.Users.FirstOrDefaultAsync();
        var locations = await context.Locations.ToListAsync();
        var categories = await context.Categories.ToListAsync();

        if (organizer == null || !locations.Any() || !categories.Any())
        {
            // We cannot seed events if we don't have dependencies
            return;
        }

        var events = new List<Event>
        {
            new Event
            {
                Title = "Tech Innovation Summit 2024",
                Description = "A complete day dedicated to the latest trends in software development and AI.",
                StartDate = DateTime.UtcNow.AddDays(10), // 10 days in the future
                EndDate = DateTime.UtcNow.AddDays(10).AddHours(8),
                Capacity = 200,
                RegisteredCount = 0,
                Status = EventStatus.Published,
                ImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?auto=format&fit=crop&q=80",
                OrganizerId = organizer.Id,
                LocationId = locations[0].Id, // Grand Conference Hall
                CategoryId = categories.FirstOrDefault(c => c.Name == "Technology")?.Id ?? categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new Event
            {
                Title = "Summer Music Festival",
                Description = "Live music, food trucks, and great vibes in the open air.",
                StartDate = DateTime.UtcNow.AddDays(25),
                EndDate = DateTime.UtcNow.AddDays(25).AddHours(6),
                Capacity = 100,
                RegisteredCount = 0,
                Status = EventStatus.Published,
                ImageUrl = "https://images.unsplash.com/photo-1501281668745-f7f57925c3b4?auto=format&fit=crop&q=80",
                OrganizerId = organizer.Id,
                LocationId = locations[1].Id, // Community Center Garden
                CategoryId = categories.FirstOrDefault(c => c.Name == "Music")?.Id ?? categories[0].Id,
                CreatedAt = DateTime.UtcNow
            },
            new Event
            {
                Title = "Startup Networking Night",
                Description = "Meet founders, investors, and developers.",
                StartDate = DateTime.UtcNow.AddDays(5),
                EndDate = DateTime.UtcNow.AddDays(5).AddHours(3),
                Capacity = 50,
                RegisteredCount = 0,
                Status = EventStatus.Published,
                ImageUrl = "https://images.unsplash.com/photo-1515187029135-18ee286d815b?auto=format&fit=crop&q=80",
                OrganizerId = organizer.Id,
                LocationId = locations[2].Id, // Tech Hub
                CategoryId = categories.FirstOrDefault(c => c.Name == "Business")?.Id ?? categories[0].Id,
                CreatedAt = DateTime.UtcNow
            }
        };

        await context.Events.AddRangeAsync(events);
        await context.SaveChangesAsync();
    }
}