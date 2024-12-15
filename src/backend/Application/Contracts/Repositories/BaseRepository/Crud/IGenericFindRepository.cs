namespace Application.Contracts.Repositories.BaseRepository.Crud;

public interface IGenericFindRepository<T> where T : BaseEntity
{
    Task<Result<T?>> GetByIdAsync(int id);
    Task<Result<IEnumerable<T>>> GetAllAsync();
    Task<Result<IEnumerable<T>>> FindAsync(Expression<Func<T, bool>> expression);
}