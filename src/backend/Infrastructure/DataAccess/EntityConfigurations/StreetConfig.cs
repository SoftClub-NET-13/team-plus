namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class StreetConfig : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany<Address>()
            .WithOne(x => x.Street)
            .HasForeignKey(x => x.StreetId);

        builder.HasMany<Location>()
            .WithOne(x => x.Street)
            .HasForeignKey(x => x.StreetId);

        builder.HasOne<City>()
            .WithMany(x => x.Streets)
            .HasForeignKey(x => x.CityId);
    }
}