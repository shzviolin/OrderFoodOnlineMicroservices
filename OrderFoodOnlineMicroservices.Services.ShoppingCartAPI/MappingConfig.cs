using AutoMapper;
using OrderFoodOnlineMicroservices.Services.ShoppingCartAPI.Models;
using OrderFoodOnlineMicroservices.Services.ShoppingCartAPI.Models.Dto;

namespace OrderFoodOnlineMicroservices.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
