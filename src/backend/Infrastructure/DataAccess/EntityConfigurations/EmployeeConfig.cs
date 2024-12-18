namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<Location>()
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.Id);


        builder.HasMany<Journal>()
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId);

        builder.HasMany<EmployeeSpecialization>()
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId);
    }
}