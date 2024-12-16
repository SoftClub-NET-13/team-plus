using Domain.Extensions;

namespace Infrastructure.ImplementationContract.Repositories.BaseRepository;

public class GenericRepository<T>(DataContext dbContext) : IGenericRepository<T> where T : BaseEntity
{
    public async Task<Result<int>> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }

    public async Task<Result<int>> AddRangeAsync(IEnumerable<T> entities)
    {
        await dbContext.Set<T>().AddRangeAsync(entities);
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }

    public async Task<Result<int>> DeleteAsync(Guid id)
    {
        T? entity = await dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return Result<int>.Failure(Error.NotFound());

        entity.ToDelete();
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }

    public async Task<Result<int>> DeleteAsync(T value)
    {
        T? entity = await dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(x => x.Id == value.Id);
        if (entity == null)
            return Result<int>.Failure(Error.NotFound());

        entity.ToDelete();
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }

    public async Task<Result<IEnumerable<T>>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return Result<IEnumerable<T>>
            .Success(await dbContext.Set<T>()
                .Where(expression).ToListAsync());
    }

    public async Task<Result<IEnumerable<T>>> GetAllAsync()
    {
        return Result<IEnumerable<T>>
            .Success(await dbContext.Set<T>()
                .ToListAsync());
    }

    public async Task<Result<T?>> GetByIdAsync(Guid id)
    {
        T? res = await dbContext.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id);
        return res != null
            ? Result<T?>.Success(res)
            : Result<T?>.Failure(Error.NotFound());
    }

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