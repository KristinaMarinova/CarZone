using CarZone.Data;

namespace CarZone.Services.jwtAuth.Responses
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }
    }
}
