using Jwt.Core.Plugins.Authentication.Models;

namespace Jwt.Core.Plugins.Authentication
{
    public interface IActiveUserService
    {
        UserInfo UserInfo { get; }
        int UserId { get; }
        string FullName { get; }
    }
}
