namespace Infrastructure.ImplementationContract.Repositories;

public class SpecializationRepository(DataContext dbContext)
    : GenericRepository<Specialization>(dbContext), ISpecializationRepository;