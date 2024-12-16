namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class StreetConfig : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder.HasMany<Address>()
            .WithOne(x => x.Street)
            .HasForeignKey(x => x.StreetId);
    }
}