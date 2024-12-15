namespace Infrastructure.ImplementationContract.Repositories.BaseRepository.Crud;

public class GenericUpdateRepository<T>(DataContext dbContext) : IGenericUpdateRepository<T> where T : BaseEntity
{
    public async Task<Result<int>> UpdateAsync(T value)
    {
        dbContext.Set<T>().AsTracking();
        dbContext.Set<T>().Update(value);
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }

    public async Task<Result<int>> UpdateRangeAsync(IEnumerable<T> value)
    {
        dbContext.Set<T>().AsTracking();
        dbContext.Set<T>().UpdateRange(value);
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }
}