using AutoMapper;
using OrderFoodOnlineMicroservices.Services.CouponAPI.Models;
using OrderFoodOnlineMicroservices.Services.CouponAPI.Models.Dto;

namespace OrderFoodOnlineMicroservices.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });

            return mappingConfig;
        }
    }
}
