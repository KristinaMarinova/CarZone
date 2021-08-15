using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CarZone.Services
{
    public class UserContext
    {
        public int UserId { get; }

        public UserContext(IHttpContextAccessor http)
        {
            var user = http.HttpContext.User;
            if(user != null)
            {
                var claim = user.FindFirst(ClaimTypes.NameIdentifier);
                if (claim != null)
                {
                    this.UserId = int.Parse(claim.Value);
                }
            }
        }
    }
}
