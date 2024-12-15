using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Address : BaseEntity
{
    public string? HouseNumber { get; set; }
    public string? ApartmentNumber { get; set; }
    public HomeType HomeType { get; set; }
    public Guid StreetId { get; set; }
    
    //navigation properties
    public Street? Street { get; set; }
    public Location? Location { get; set; }
}