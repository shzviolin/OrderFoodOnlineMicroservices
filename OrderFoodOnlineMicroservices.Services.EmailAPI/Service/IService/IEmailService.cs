using OrderFoodOnlineMicroservices.Services.EmailAPI.Dto;

namespace OrderFoodOnlineMicroservices.Services.EmailAPI.Service.IService
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
    }
}
