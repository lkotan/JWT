using Jwt.Core.Models.UserRole;
using System.Collections.Generic;

namespace Jwt.Core.Plugins.Authentication.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(int userId,List<UserRoleModel> userRoles);
    }
}