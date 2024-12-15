namespace Application.Contracts.Services.BaseService.Crud;

public interface IGetService
{
    Task<Result<PagedResponse<IEnumerable<TR>>>> GetAlLAsync<TR, TF>(TF filter) where TF : BaseFilter;
    Task<Result<TR>> GetByIdAsync<TR>(Guid id);
}