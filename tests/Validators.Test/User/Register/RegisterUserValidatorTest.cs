using CommonTestUtilities.Requests;
using FluentAssertions;
using FluentValidation;
using Moq;
using MyMarket.Application.Validator;
using MyMarket.Communication.Requests;

namespace Validators.Test.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var validator = new RegisterProductValidator();

            var request = RequestRegisterProductJsonBuilder.Build();

            request.Name = "";

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.True(result.IsValid);

            // Assert with FluentAssertions (mais comum no mercado)
            //result.IsValid.Should().BeTrue();

        }
    }
}
