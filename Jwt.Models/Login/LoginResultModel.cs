using Jwt.Models.Role;
using Jwt.Core.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Models.Login
{
    public class LoginResultModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public List<UserRoleModel> UserRoles { get; set; }
    }
}
