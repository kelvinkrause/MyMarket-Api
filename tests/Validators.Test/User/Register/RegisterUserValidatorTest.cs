using CommonTestUtilities.Requests;
using FluentAssertions;
using MyMarket.Application.Validator;
using MyMarket.Exceptions.Resources;

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

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.True(result.IsValid);

            // Assert with FluentAssertions (mais comum no mercado)
            //result.IsValid.Should().BeTrue();

        }

        [Fact]
        public void Error_Name_Empty()
        {
            var validator = new RegisterProductValidator();

            var request = RequestRegisterProductJsonBuilder.Build();

            request.Name = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_NAME_REQUIRED));
        }

        [Fact]
        public void Error_Name_MaxLength_100()
        {
            var validator = new RegisterProductValidator();

            var request = RequestRegisterProductJsonBuilder.Build();

            request.Name = "AureliusMagnificusSupremusDraconisEternumValerianusCelestialisImperiumLuminareInvictusPhoenixArcanumMysterialis";

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_NAME_MAX_LENGTH));

        }
    }
}
