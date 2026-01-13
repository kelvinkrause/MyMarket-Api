using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;

namespace MyMarket.Application.UseCase.Product.Register
{
    public class RegisterProductUseCase
    {
        public Task<ResponseRegisteredProductJson> Execute(RequestRegisteredProductJson request)
        {

            Validate(request);
            // Mapear a entidade
            // Salvar no banco de dados

            var response = new ResponseRegisteredProductJson
            {
                Id = 1,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreatedAt = DateTime.UtcNow
            };

            return Task.FromResult(response);
        }

        private void Validate(RequestRegisteredProductJson request)
        {
            // Implementar validações necessárias
        }
    }
}

