using System.Threading.Tasks;
using CarZone.Data;
using CarZone.Services.jwtAuth.Requests;
using CarZone.Services.jwtAuth.Responses;

namespace CarZone.Services.jwtAuth.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<LoginResponse> Register(User user);
        User UpdateUserInfo(int id, User user);
    }
}
