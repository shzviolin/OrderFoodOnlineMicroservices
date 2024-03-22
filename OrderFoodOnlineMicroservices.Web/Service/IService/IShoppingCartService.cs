using OrderFoodOnlineMicroservices.Web.Models.Dto;

namespace OrderFoodOnlineMicroservices.Web.Service.IService
{
    public interface IShoppingCartService
    {
        Task<ResponseDto?> GetCartByUserIdAsync(string userId);
        Task<ResponseDto?> UpsertCartAsync(CartDto cartDto);
        Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId);
        Task<ResponseDto?> ApplyCouponsAsync(CartDto cartDto);
    }
}
