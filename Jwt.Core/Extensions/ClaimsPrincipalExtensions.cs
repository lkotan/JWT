using Jwt.Core.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Jwt.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static string GetName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindAll(ClaimTypes.Name)?.Select(x => x.Value).FirstOrDefault();
        }
        public static string GetNameIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindAll(ClaimTypes.NameIdentifier)?.Select(x => x.Value).FirstOrDefault();
        }

        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.FindAll(ClaimTypes.NameIdentifier)?.Select(x => x.Value).FirstOrDefault()?.ToInt() ?? 0;
        }
    }
}
