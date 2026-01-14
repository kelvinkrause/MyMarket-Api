using MyMarket.Application.Validator;
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
            var validator = new RegisterProductValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ArgumentException(string.Join("; ", errors));
            }
        }
    }
}

