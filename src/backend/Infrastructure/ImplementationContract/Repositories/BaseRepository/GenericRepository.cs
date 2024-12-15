using System.Linq.Expressions;
using Application.Contracts.Repositories.BaseRepository;
using Application.Extensions.ResultPattern;
using Domain.Common;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ImplementationContract.Repositories.BaseRepository;

public class GenericRepository<T>(DataContext dbContext) : IGenericRepository<T> where T : BaseEntity
{
    public async Task<Result<int>> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError("Couldn't add data to database'"));
    }

    public async Task<Result<int>> AddRangeAsync(IEnumerable<T> entities)
    {
        await dbContext.Set<T>().AddRangeAsync(entities);
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError("Couldn't add data's to database'"));
    }

    public async Task<Result<int>> DeleteAsync(Guid id)
    {
        BaseEntity? entity = await dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return Result<int>.Failure(Error.NotFound());
        entity.Version++;
        entity.IsDeleted = true;
        entity.UpdatedAt = DateTimeOffset.Now;
        entity.DeletedAt = DateTimeOffset.Now;
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }

    public async Task<Result<int>> DeleteAsync(T value)
    {
        BaseEntity? entity = await dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(x => x.Id == value.Id);
        if (entity == null)
            return Result<int>.Failure(Error.NotFound());
        entity.Version++;
        entity.IsDeleted = true;
        entity.UpdatedAt = DateTimeOffset.Now;
        entity.DeletedAt = DateTimeOffset.Now;
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
        return Result<T?>
            .Success(await dbContext.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<Result<int>> UpdateAsync(T value)
    {
        dbContext.Set<T>().Update(value);
        int res = await dbContext.SaveChangesAsync();
        return res > 0
            ? Result<int>.Success(res)
            : Result<int>.Failure(Error.InternalServerError());
    }
}