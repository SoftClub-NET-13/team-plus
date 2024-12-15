namespace Application.Contracts.Services.BaseService.Crud;

public interface IAddService
{
    Task<BaseResult> CreateAsync<T>(T entity);
    Task<BaseResult> CreateRangeAsync<T>(IEnumerable<T> entity);
}