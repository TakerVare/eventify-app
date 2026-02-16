using EventifyApi.Models.DTOs.Categories;
using EventifyApi.Models.DTOs.Locations;
using EventifyApi.Models.Entities.Enums;

namespace EventifyApi.Models.DTOs.Events;

/// <summary>
/// DTO resumido de evento (para listados)
/// </summary>
public class EventSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Capacity { get; set; }
    public int RegisteredCount { get; set; }
    public string? ImageUrl { get; set; }
    public EventStatus Status { get; set; }

    // Relaciones simplificadas (solo IDs y nombres)
    public int LocationId { get; set; }    
    public int CategoryId { get; set; }

    // AÑADIMOS objetos DTO anidados:
    public LocationSummaryDto? Location { get; set; }
    public CategoryDto? Category { get; set; }
    public string CategoryColor { get; set; } = string.Empty;

    // Propiedades calculadas
    public bool IsFull => RegisteredCount >= Capacity;
    public int AvailableSpots => Math.Max(0, Capacity - RegisteredCount);
}
