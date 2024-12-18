namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<Location>()
            .WithOne(x => x.Address)
            .HasForeignKey<Location>(x => x.AddressId);
        
        builder.HasOne<Street>()
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.StreetId);
    }
}