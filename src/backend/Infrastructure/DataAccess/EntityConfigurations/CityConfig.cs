using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasOne<Country>().WithMany(x => x.Cities).HasForeignKey(x=>x.CountryId);
        builder.HasMany<Location>().WithOne(x => x.City).HasForeignKey(x=>x.CityId);
        builder.HasMany<Street>().WithOne(x => x.City).HasForeignKey(x=>x.CityId);
        builder.HasAlternateKey(x => x.Name);
        builder.HasAlternateKey(x => x.PostalCode);
    }
}