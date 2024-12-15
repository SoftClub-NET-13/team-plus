using Domain.Common;
using Domain.Constants;

namespace Domain.Entities;

public sealed class City : BaseEntity
{
    public string ImageUrl { get; set; } = FileData.DefaultCityImage;
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    public double Area { get; set; }
    public bool IsCapital { get; set; }
    public string PostalCode { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TimeZoneInfo? TimeZone { get; set; }
    public Guid CountryId { get; set; }

    //navigation properties
    public Country? Country { get; set; }
    public ICollection<Street> Streets { get; set; } = [];
    public ICollection<Location> Locations { get; set; } = [];
}