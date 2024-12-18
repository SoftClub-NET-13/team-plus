namespace Infrastructure.DataAccess.EntityConfigurations;

public sealed class JournalConfig : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Employee>()
            .WithMany(x => x.Journals)
            .HasForeignKey(x => x.EmployeeId);
    }
}