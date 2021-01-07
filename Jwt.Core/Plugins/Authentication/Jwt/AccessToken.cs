using System;

namespace Jwt.Core.Plugins.Authentication.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}
