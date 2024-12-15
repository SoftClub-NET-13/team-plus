namespace Application.Contracts.Repositories.BaseRepository;

public interface IGenericRepository<T> :
    IGenericAddRepository<T>,
    IGenericUpdateRepository<T>,
    IGenericDeleteRepository<T>,
    IGenericFindRepository<T> where T : BaseEntity;