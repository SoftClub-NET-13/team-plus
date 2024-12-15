namespace Application.Contracts.Repositories.BaseRepository.Crud;

public interface IGenericDeleteRepository<T> where T : BaseEntity
{
    Task<Result<int>> DeleteAsync(Guid id);
    Task<Result<int>> DeleteAsync(T value);
    Task<Result<int>> DeleteRangeAsync(IEnumerable<T> value);
}