using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations;

public class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasAlternateKey(l => new { l.CountryId, l.CityId, l.StreetId,l.AddressId });
        builder.HasAlternateKey(x => x.AddressId);
    }
}