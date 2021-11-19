using Refit;

using SOHome.Common.DataModels;

using System.Threading.Tasks;

namespace SOHome.Common.Interfaces
{
    public interface IRestClient
    {
        [Post("/api/account/register")]
        Task<UserDto> RegisterAsync(RegisterModel model);
        [Post("/api/account/login")]
        Task<UserDto> LoginAsync(LoginModel model);
    }
}
