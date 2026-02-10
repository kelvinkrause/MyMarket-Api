using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyMarket.Application.Interfaces;
using MyMarket.Application.Services.AutoMapper;
using MyMarket.Application.UseCase.Product.Register;
using MyMarket.Application.Validator;

namespace MyMarket.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
            AddValidators(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterProductUseCase, RegisterProductUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RegisterProductValidator>();
        }
    }
}
