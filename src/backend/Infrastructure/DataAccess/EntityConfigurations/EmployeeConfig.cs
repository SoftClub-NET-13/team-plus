namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
    }
}