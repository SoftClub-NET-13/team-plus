namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany<City>()
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);

        builder.HasMany<Location>()
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);
    }
}