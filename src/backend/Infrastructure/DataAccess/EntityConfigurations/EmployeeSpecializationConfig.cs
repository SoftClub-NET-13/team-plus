using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.EntityConfigurations;

public class EmployeeSpecializationConfig:IEntityTypeConfiguration<EmployeeSpecialization>
{
    public void Configure(EntityTypeBuilder<EmployeeSpecialization> builder)
    {
    }
}