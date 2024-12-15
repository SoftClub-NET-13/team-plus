using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasMany<Journal>().WithOne(x => x.Employee).HasForeignKey(x=>x.EmployeeId);
        builder.HasOne<Location>().WithMany(x => x.Employees).HasForeignKey(x=>x.LocationId);
        builder.HasAlternateKey(x => x.Email);
        builder.HasAlternateKey(x => x.PhoneNumber);
    }
}