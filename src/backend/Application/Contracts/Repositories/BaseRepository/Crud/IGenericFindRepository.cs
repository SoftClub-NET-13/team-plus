namespace Application.Contracts.Repositories.BaseRepository.Crud;

public interface IGenericFindRepository<T> where T : BaseEntity
{
    Task<Result<T?>> GetByIdAsync(Guid id);
    Task<Result<IEnumerable<T>>> GetAllAsync();
    Result<IQueryable<T>> Find(Expression<Func<T, bool>> expression);
}