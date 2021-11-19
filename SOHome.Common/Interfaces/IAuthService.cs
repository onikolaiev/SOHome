using SOHome.Common.DataModels;

using System.Threading.Tasks;

namespace SOHome.Common.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterModel model);
        Task<UserDto> LoginAsync(LoginModel model);
        Task LogoutAsync();
    }
}
