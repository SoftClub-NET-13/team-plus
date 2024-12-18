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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
    }
}