namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class LocationConfig : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(l =>
            new
            {
                l.CountryId,
                l.CityId,
                l.StreetId,
                l.AddressId
            });
        builder.HasAlternateKey(x => x.AddressId);

        builder.HasMany<Employee>()
            .WithOne(x => x.Location)
            .HasForeignKey(x => x.LocationId);
        
        builder.HasOne<Country>()
            .WithMany(x => x.Locations)
            .HasForeignKey(x => x.CountryId);

        builder.HasOne<City>()
            .WithMany(x => x.Locations)
            .HasForeignKey(x => x.CityId);

        builder.HasOne<Street>()
            .WithMany(x => x.Locations)
            .HasForeignKey(x => x.StreetId);

        builder.HasOne<Address>()
            .WithOne(x => x.Location)
            .HasForeignKey<Location>(x => x.AddressId);

    }
}