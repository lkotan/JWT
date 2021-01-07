using Jwt.Core.Plugins.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Core.Plugins.Authentication
{
    public interface ILoggedInUsers
    {
        List<UserInfo> UserInfo { get; set; }
    }
}
