using System.Threading.Tasks;
using WebCarsProject.Data;
using WebCarsProject.Services.jwtAuth.Requests;
using WebCarsProject.Services.jwtAuth.Responses;

namespace WebCarsProject.Services.jwtAuth.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<LoginResponse> Register(User user);
        User UpdateUserInfo(int id, User user);
    }
}
