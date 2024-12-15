using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations;

public class CountryConfig: IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasAlternateKey(x => x.Name);
        builder.HasAlternateKey(x => x.CurrencyCode);
        builder.HasAlternateKey(x => x.PhoneCode);
        builder.HasAlternateKey(x => x.Code);
    }
}