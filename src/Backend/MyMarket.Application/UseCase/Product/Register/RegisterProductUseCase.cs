using AutoMapper;
using MyMarket.Application.Interfaces;
using MyMarket.Application.Validator;
using MyMarket.Communication.Requests;
using MyMarket.Communication.Response;
using MyMarket.Domain.Repositories;
using MyMarket.Domain.Repository.Product;
using MyMarket.Exceptions.Exceptions;
using MyMarket.Exceptions.Resources;

namespace MyMarket.Application.UseCase.Product.Register
{
    public class RegisterProductUseCase : IRegisterProductUseCase
    {
        private readonly IProductReadOnlyRepository _productReadOnlyRepository;
        private readonly IProductWriteOnlyRepository _productWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterProductUseCase(
            IProductReadOnlyRepository productReadOnlyRepository,
            IProductWriteOnlyRepository productWriteOnlyRepository,
            IMapper mapper)
        {
            _productReadOnlyRepository = productReadOnlyRepository;
            _productWriteOnlyRepository = productWriteOnlyRepository;
            _mapper = mapper;
        }
        public async Task<ResponseRegisteredProductJson> Execute(RequestRegisteredProductJson request)
        {

            await ValidateAsync(request);

            var product = _mapper.Map<Domain.Entities.Product>(request);

            await _productWriteOnlyRepository.AddAsync(product);

            await _unitOfWork.CommitAsync();

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

        private async Task ValidateAsync(RequestRegisteredProductJson request)
        {
            var validator = new RegisterProductValidator();

            var result = validator.Validate(request);

            var existingProduct = await _productReadOnlyRepository.ExistsActiveProduct(request.Barcode);

            if(!existingProduct)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessageException.PRODUCT_BARCODE_ALREADY_EXISTS));
            

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}

