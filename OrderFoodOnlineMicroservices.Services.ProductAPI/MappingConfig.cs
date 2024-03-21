using AutoMapper;
using OrderFoodOnlineMicroservices.Services.ProductAPI.Models;
using OrderFoodOnlineMicroservices.Services.ProductAPI.Models.Dto;

namespace OrderFoodOnlineMicroservices.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
