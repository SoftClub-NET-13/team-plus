namespace Application.Contracts.Services.BaseService;

public interface IBaseService
    : IAddService,
        IDeleteService,
        IUpdateService,
        IGetService;