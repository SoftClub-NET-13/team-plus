namespace Domain.Entities;

public sealed class Street : BaseEntity
{
    public string ImageUrl { get; set; } = FileData.DefaultStreetImage;
    public string Name { get; set; } = string.Empty;
    public Guid CityId { get; set; }
    public City City { get; set; } = null!;

    public ICollection<Location> Locations { get; set; } = [];
    public ICollection<Address> Addresses { get; set; } = [];
}