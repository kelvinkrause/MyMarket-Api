using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;

namespace MyMarket.Application.Interfaces
{
    public interface IRegisterProductUseCase
    {
        Task<ResponseRegisteredProductJson> Execute(RequestRegisterProductJson request);
    }
}
