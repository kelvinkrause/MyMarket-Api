using AutoMapper;
using MyMarket.Application.Interfaces;
using MyMarket.Application.Validator;
using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;
using MyMarket.Domain.Repository.Product;
using MyMarket.Exceptions.Exceptions;

namespace MyMarket.Application.UseCase.Product.Register
{
    public class RegisterProductUseCase : IRegisterProductUseCase
    {
        private readonly IProductReadOnlyRepository _productReadOnlyRepository;
        private readonly IProductWriteOnlyRepository _productWriteOnlyRepository;
        private readonly IMapper _mapper;
        public async Task<ResponseRegisteredProductJson> Execute(RequestRegisteredProductJson request)
        {

            Validate(request);

            //var autoMapper = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new AutoMapping());
            //}).CreateMapper();

            //var autoMapper = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<RequestRegisteredProductJson, Domain.Entities.Product>();
            //}).CreateMapper();

            var product = _mapper.Map<Domain.Entities.Product>(request);

            await _productWriteOnlyRepository.AddAsync(product);

            // Salvar no banco de dados

            var response = new ResponseRegisteredProductJson
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreatedOn = DateTime.UtcNow
            };

            return response;
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

