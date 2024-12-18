namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class SpecializationConfig : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany<EmployeeSpecialization>()
            .WithOne(x => x.Specialization)
            .HasForeignKey(x => x.SpecializationId);
    }
}