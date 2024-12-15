namespace Application.Contracts.Services.BaseService.Crud;

public interface IUpdateService
{
    Task<BaseResult> UpdateAsync<T>(T entity, Guid id);
}