using AutoMapper;
using MyMarket.Communication.Requests;
using MyMarket.Domain.Entities;

namespace MyMarket.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }
        
        private void RequestToDomain()
        {
            CreateMap<RequestRegisteredProductJson, Product>();
        }
    }
}
