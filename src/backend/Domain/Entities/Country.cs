using Domain.Common;
using Domain.Constants;
using Domain.Enums;

namespace Domain.Entities;

public sealed class Country : BaseEntity
{
    public string ImageUrl { get; set; } = FileData.DefaultCountryImage;
    public string Name { get; set; } = string.Empty;
    public CountryCode Code { get; set; }
    public Region Region { get; set; }
    public double Area { get; set; }
    public long Population { get; set; }
    public string FlagUrl { get; set; } = FileData.DefaultFlag;
    public PhoneCode PhoneCode { get; set; }
    public CurrencyCode CurrencyCode { get; set; }


    public ICollection<City> Cities { get; set; } = [];
    public ICollection<Location> Locations { get; set; } = [];
}