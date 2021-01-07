using System.Collections.Generic;
using Jwt.Core.Plugins.Authentication.Models;

namespace Jwt.Core.Plugins.Authentication
{
    public class LoggedInUsers
    {
        public LoggedInUsers()
        {
            UserInfo = new List<UserInfo>();
        }
        public List<UserInfo> UserInfo { get; set; }
    }
}
