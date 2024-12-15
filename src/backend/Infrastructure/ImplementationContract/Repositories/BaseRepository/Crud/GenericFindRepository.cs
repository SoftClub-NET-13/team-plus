using System.Linq.Expressions;
using Application.Contracts.Repositories.BaseRepository.Crud;
using Application.Extensions.ResultPattern;
using Domain.Common;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ImplementationContract.Repositories.BaseRepository.Crud;

public class GenericFindRepository<T>(DataContext dbContext) : IGenericFindRepository<T> where T : BaseEntity
{
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
}