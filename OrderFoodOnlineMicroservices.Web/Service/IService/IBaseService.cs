using OrderFoodOnlineMicroservices.Web.Models;
using OrderFoodOnlineMicroservices.Web.Models.Dto;

namespace OrderFoodOnlineMicroservices.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
