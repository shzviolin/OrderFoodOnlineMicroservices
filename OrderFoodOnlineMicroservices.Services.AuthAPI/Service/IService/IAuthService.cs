using OrderFoodOnlineMicroservices.Services.AuthAPI.Models.Dto;

namespace OrderFoodOnlineMicroservices.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleNmae);
    }
}
