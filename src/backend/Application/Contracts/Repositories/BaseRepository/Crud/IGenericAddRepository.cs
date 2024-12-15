namespace Application.Contracts.Repositories.BaseRepository.Crud;

public interface IGenericAddRepository<T> where T : BaseEntity
{
    Task<Result<int>> AddAsync(T entity);
    Task<Result<int>> AddRangeAsync(IEnumerable<T> entities);
}