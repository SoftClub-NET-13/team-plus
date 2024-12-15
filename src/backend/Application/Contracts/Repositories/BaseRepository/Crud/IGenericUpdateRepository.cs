namespace Application.Contracts.Repositories.BaseRepository.Crud;

public interface IGenericUpdateRepository<T> where T : BaseEntity
{
    Task<Result<int>> UpdateAsync(T value);
    Task<Result<int>> UpdateRangeAsync(IEnumerable<T> values);
}