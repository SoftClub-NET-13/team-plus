namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class EmployeeSpecializationConfig : IEntityTypeConfiguration<EmployeeSpecialization>
{
    public void Configure(EntityTypeBuilder<EmployeeSpecialization> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<Employee>()
            .WithMany(x => x.EmployeeSpecializations)
            .HasForeignKey(x => x.EmployeeId);
        
        builder.HasOne<Specialization>()
            .WithMany(x => x.EmployeeSpecializations)
            .HasForeignKey(x => x.SpecializationId);
        
        builder.HasAlternateKey(x
            => new { x.EmployeeId, x.SpecializationId });
    }
}