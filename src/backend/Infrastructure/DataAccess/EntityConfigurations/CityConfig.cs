namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasMany<Location>()
            .WithOne(x => x.City)
            .HasForeignKey(x => x.CityId);

        builder.HasMany<Street>()
            .WithOne(x => x.City)
            .HasForeignKey(x => x.CityId);

        builder.HasOne<Country>()
            .WithMany(x => x.Cities)
            .HasForeignKey(x => x.CountryId);
    }
}