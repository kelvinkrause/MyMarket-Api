using CommonTestUtilities.Requests;
using FluentAssertions;
using MyMarket.Application.Validator;
using MyMarket.Exceptions.Resources;

namespace Validators.Test.User.Register
{
    public class RegisterProductValidatorTest
    {
        [Fact]
        public void Success()
        {
            // Arrange = Configuração do teste, ou seja, a criação do validator e do request que queremos validar usando esse validator.
            var validator = new RegisterProductValidator();

            var request = RequestRegisterProductJsonBuilder.Build();

            // Act = Ação que queremos testar, ou seja, a validação do request usando o validator criado para isso.
            var result = validator.Validate(request);

            // Assert = Verificação do resultado da ação, ou seja, se o resultado da validação é o esperado (neste caso, válido).
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

        [Fact]
        public void Error_Description_MaxLength_500()
        {
            var validator = new RegisterProductValidator();

            var request = RequestRegisterProductJsonBuilder.Build();

            request.Description = "Você já parou para pensar no tempo que perde com produtos que não entregam o que prometem? O [Nome do Produto] chegou para romper essa barreira, unindo uma tecnologia de última geração a um design que transborda sofisticação e funcionalidade. Projetado meticulosamente para os usuários mais exigentes, este produto não é apenas um acessório, mas uma extensão do seu estilo de vida dinâmico.\r\nCada curva e componente foi pensado para oferecer uma experiência ergonômica inigualável, garantindo que o uso prolongado seja sempre prazeroso e eficiente. Esqueça as complicações: aqui, a praticidade é a regra. Com uma interface intuitiva e materiais de alta resistência, o [Nome do Produto] suporta o ritmo acelerado do cotidiano enquanto mantém sua aparência de novo por muito mais tempo.";

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_DESCRIPTION_MAX_LENGTH));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Error_Price_LessThanOrEqualTo_0(decimal price)
        {
            var validator = new RegisterProductValidator();

            var request = RequestRegisterProductJsonBuilder.Build();

            request.Price = price;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_PRICE_INVALID));
        }

        [Fact]
        public void Error_StockQuantity_LessThan_0()
        {

            var validator = new RegisterProductValidator();
            var request = RequestRegisterProductJsonBuilder.Build();

            request.StockQuantity = -1;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_STOCK_QUANTITY_INVALID));
        }

        [Fact]
        public void Error_Category_Empty()
        {
            var validator = new RegisterProductValidator();
            var request = RequestRegisterProductJsonBuilder.Build();

            request.Category = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_CATEGORY_REQUIRED));
        }

        [Fact]
        public void Error_Barcode_Empty()
        {
            var validator = new RegisterProductValidator();
            var request = RequestRegisterProductJsonBuilder.Build();

            request.Barcode = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_BARCODE_REQUIRED));
        }

        [Theory]
        [InlineData("ABC")]
        [InlineData("123456789101A")]
        [InlineData("12345678901234")]
        public void Error_Barcode_InvalidFormat(string barcode)
        {
            var validator = new RegisterProductValidator();
            var request = RequestRegisterProductJsonBuilder.Build();

            request.Barcode = barcode;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceMessageException.PRODUCT_BARCODE_INVALID_FORMAT));

        }
    }
}