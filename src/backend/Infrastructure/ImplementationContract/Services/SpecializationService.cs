

namespace Infrastructure.ImplementationContract.Services;

public class SpecializationService(ISpecializationRepository repository) : ISpecializationService
{
    public async Task<Result<PagedResponse<IEnumerable<SpecializationReadInfo>>>> GetAllAsync(
        SpecializationFilter filter)
    {
        Expression<Func<Specialization, bool>> filterExpression = spec =>
            (string.IsNullOrEmpty(filter.Name) || spec.Name.ToLower().Contains(filter.Name.ToLower())) &&
            (string.IsNullOrEmpty(filter.Code) || spec.Code.ToLower().Contains(filter.Code.ToLower()));

        List<SpecializationReadInfo> query = (await repository
            .FindAsync(filterExpression)).Value!.Select(x => x.ToRead()).ToList();

        int count = query.Count();

        IEnumerable<SpecializationReadInfo> spec =
            query.Page(filter.PageNumber, filter.PageSize);

        PagedResponse<IEnumerable<SpecializationReadInfo>> res =
            PagedResponse<IEnumerable<SpecializationReadInfo>>.Create(filter.PageNumber, filter.PageSize, count, spec);

        return Result<PagedResponse<IEnumerable<SpecializationReadInfo>>>.Success(res);
    }

    public async Task<Result<SpecializationReadInfo>> GetByIdAsync(Guid id)
    {
        Result<Specialization?> res = await repository.GetByIdAsync(id);
        if (!res.IsSuccess) return Result<SpecializationReadInfo>.Failure(res.Error);

        return Result<SpecializationReadInfo>.Success(res.Value!.ToRead());
    }

    public async Task<BaseResult> CreateAsync(SpecializationCreateInfo createInfo)
    {
        bool conflict = (await repository.GetAllAsync()).Value!.Any(x =>
            x.Code.ToLower() == createInfo.Code.ToLower() ||
            x.Name.ToLower() == createInfo.Name.ToLower());
        if (conflict) return BaseResult.Failure(Error.Conflict());

        Result<int> res = await repository.AddAsync(createInfo.ToEntity());

        return res.IsSuccess
            ? BaseResult.Success()
            : BaseResult.Failure(res.Error);
    }

    public async Task<BaseResult> UpdateAsync(Guid id, SpecializationUpdateInfo updateInfo)
    {
        Result<Specialization?> res = await repository.GetByIdAsync(id);

        if (!res.IsSuccess) return BaseResult.Failure(Error.NotFound());
        
        bool conflict = (await repository.GetAllAsync()).Value!.Any(x =>
            (x.Code.ToLower() == updateInfo.Code.ToLower() ||
             x.Name.ToLower() == updateInfo.Name.ToLower()) && x.Id != id);
        if (conflict) return BaseResult.Failure(Error.Conflict());

        Result<int> result = await repository.UpdateAsync(res.Value!.ToEntity(updateInfo));

        return result.IsSuccess
            ? BaseResult.Success()
            : BaseResult.Failure(result.Error);
    }

    public async Task<BaseResult> DeleteAsync(Guid id)
    {
        Result<Specialization?> res = await repository.GetByIdAsync(id);
        if (res.IsSuccess) return BaseResult.Failure(Error.NotFound());

        Result<int> result = await repository.DeleteAsync(id);

        return result.IsSuccess
            ? BaseResult.Success()
            : BaseResult.Failure(result.Error);
    }
}