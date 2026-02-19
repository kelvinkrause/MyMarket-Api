using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using FluentAssertions;
using MyMarket.Application.UseCase.Product.Register;
using MyMarket.Application.Validator;

namespace UseCases.Test.Product.Register
{
    public class RegisterProductUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterProductJsonBuilder.Build();

            var useCase = CreateUseCase();
            
            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);  
        }

        private RegisterProductUseCase CreateUseCase()
        {
            var writeRepository = ProductWriteOnlyRepositoryBuilder.Build();
            var readRepository = new ProductReadOnlyRepositoryBuilder().Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var mapper = MapperBuilder.Build();
            var validate = new RegisterProductValidator();

            return new RegisterProductUseCase(readRepository, writeRepository, validate, unitOfWork, mapper);

        }
    }
}
