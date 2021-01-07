using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Jwt.Core.Extensions;
using Jwt.Core.Helpers;
using Jwt.Core.Models.UserRole;
using System.Linq;

namespace Jwt.Core.Plugins.Authentication.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private readonly JwtOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(JwtOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }
        
        public AccessToken CreateToken(int userId, List<UserRoleModel> userRoles)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwt = CreateJwtSecurityToken(_tokenOptions, userId, signingCredentials,userRoles);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                RefreshToken = Helper.CreateToken(),
                TokenExpiration = _accessTokenExpiration
            };
        }
        private JwtSecurityToken CreateJwtSecurityToken(JwtOptions tokenOptions, int userId, SigningCredentials signingCredentials,List<UserRoleModel> userRoles)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(userId,userRoles),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private static IEnumerable<Claim> SetClaims(int userId,List<UserRoleModel> userRoles)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(userId.ToString());
            claims.AddRoles(userRoles.Select(x=>x.RoleName).ToArray());
            return claims;
        }
    }
}
