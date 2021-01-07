using Jwt.Core.Extensions;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Jwt.Core.Plugins.Authentication.Models;
using System.Runtime.InteropServices;

namespace Jwt.Core.Plugins.Authentication
{
    public class UserJwtService : IActiveUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggedInUsers _loggedInUsers;

        public UserJwtService(IHttpContextAccessor httpContextAccessor, LoggedInUsers loggedInUsers)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggedInUsers = loggedInUsers;
        }
        private UserInfo GetUser()
        {
            var userInfo = _httpContextAccessor.HttpContext.User;
            var userId = userInfo.GetUserId();
            return _loggedInUsers.UserInfo.FirstOrDefault(x => x.UserId == userId);
        }
        public UserInfo UserInfo => GetUser();
        public int UserId => GetUser()?.UserId ?? 0;
        public string FullName => GetUser()?.FullName ?? "";
    }
}
