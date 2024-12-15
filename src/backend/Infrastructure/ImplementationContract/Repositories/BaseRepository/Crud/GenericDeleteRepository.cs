using Application.Contracts.Repositories.BaseRepository.Crud;
using Application.Extensions.ResultPattern;
using Domain.Common;
using Domain.Extensions;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ImplementationContract.Repositories.BaseRepository.Crud;

public class GenericDeleteRepository<T>(DataContext dbContext) : IGenericDeleteRepository<T> where T : BaseEntity
{
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
}