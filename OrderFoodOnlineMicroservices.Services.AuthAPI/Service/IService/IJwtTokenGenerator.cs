using OrderFoodOnlineMicroservices.Services.AuthAPI.Models;

namespace OrderFoodOnlineMicroservices.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
