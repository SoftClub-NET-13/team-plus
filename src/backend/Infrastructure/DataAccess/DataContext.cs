using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.DataAccess;

public sealed class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeSpecialization> EmployeeSpecializations { get; set; }
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            IMutableEntityType? baseType = entityType.BaseType;
            if (baseType != null)
            {
                modelBuilder.Entity(entityType.ClrType).UseTpcMappingStrategy();
            }
        }

        modelBuilder.FilterSoftDeletedProperties();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}