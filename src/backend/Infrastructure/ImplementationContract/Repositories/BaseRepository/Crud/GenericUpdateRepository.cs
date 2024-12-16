namespace Infrastructure.ImplementationContract.Repositories.BaseRepository.Crud;

public class GenericUpdateRepository<T>(DataContext dbContext) : IGenericUpdateRepository<T> where T : BaseEntity
{
    public async Task<Result<int>> UpdateAsync(T value)
    {
        T? existing = await dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(x => x.Id == value.Id);
        if (existing == null)
            return Result<int>.Failure(Error.NotFound());

        dbContext.Entry(existing).CurrentValues.SetValues(value);

        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }
}