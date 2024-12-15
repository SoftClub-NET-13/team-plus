using Application.Contracts.Repositories.BaseRepository.Crud;
using Application.Extensions.ResultPattern;
using Domain.Common;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ImplementationContract.Repositories.BaseRepository.Crud;

public class GenericDeleteRepository<T>(DataContext dbContext) : IGenericDeleteRepository<T> where T : BaseEntity
{
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
}