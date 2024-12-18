namespace Domain.Entities;

public sealed class Address : BaseEntity
{
    public string? HouseNumber { get; set; }
    public string? ApartmentNumber { get; set; }
    public HomeType HomeType { get; set; }

    //navigation properties
    public Guid StreetId { get; set; }
    public Street Street { get; set; } = null!;

    public Location Location { get; set; } = null!;
}