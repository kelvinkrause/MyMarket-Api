using MyMarket.Application.Services.AutoMapper;
using MyMarket.Application.Validator;
using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;
using MyMarket.Exceptions.Exceptions;

namespace MyMarket.Application.UseCase.Product.Register
{
    public class RegisterProductUseCase
    {
        public Task<ResponseRegisteredProductJson> Execute(RequestRegisteredProductJson request)
        {

            Validate(request);

            //var autoMapper = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new AutoMapping());
            //}).CreateMapper();

            var autoMapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestRegisteredProductJson, Domain.Entities.Product>();
            }).CreateMapper();

            var product = autoMapper.Map<Domain.Entities.Product>(request);

            // Mapear a entidade
            // Salvar no banco de dados

            var response = new ResponseRegisteredProductJson
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreatedOn = DateTime.UtcNow
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

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}

