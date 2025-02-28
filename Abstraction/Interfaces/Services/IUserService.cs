using Models.DTO.YourNamespace.DTOs;

namespace Abstraction.Interfaces.Services
{
    public interface IUserService
    {
        Task<int> RegisterUser(RegistrationDto registrationDto);
    }
}
