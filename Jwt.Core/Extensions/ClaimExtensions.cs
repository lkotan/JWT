using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Jwt.Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }
        public static void AddUserData(this ICollection<Claim> claims, string userData)
        {
            claims.Add(new Claim(ClaimTypes.UserData, userData));
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
