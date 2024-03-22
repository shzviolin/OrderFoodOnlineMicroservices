using OrderFoodOnlineMicroservices.Services.ShoppingCartAPI.Models.Dto;

namespace OrderFoodOnlineMicroservices.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}
