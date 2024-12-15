namespace Application.Contracts.Services.BaseService.Crud;

public interface IDeleteService
{
    Task<BaseResult> DeleteAsync(Guid id);
}