namespace Domain.Entities;

public sealed class City : BaseEntity
{
    public string ImageUrl { get; set; } = FileData.DefaultCityImage;
    public int Population { get; set; }
    public double Area { get; set; }
    public bool IsCapital { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string? Description { get; set; }

    public Guid CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public ICollection<Street> Streets { get; set; } = [];
    public ICollection<Location> Locations { get; set; } = [];
}