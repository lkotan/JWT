using Castle.DynamicProxy;
using Jwt.Core.Exceptions;
using Jwt.Core.Extensions;
using Jwt.Core.Messages;
using Jwt.Core.Plugins.Authentication;
using Jwt.Core.Utilities.Interceptors;
using Jwt.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jwt.Core.Aspects.Security
{
    public class SecurityAspect: MethodInterception
    {
        private IHttpContextAccessor _httpContextAccessor;
        private LoggedInUsers _loggedInUsers;
        public SecurityAspect()
        {

        }
        protected override void OnBefore(IInvocation invocation)
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _loggedInUsers = ServiceTool.ServiceProvider.GetService<LoggedInUsers>();

            var user = _httpContextAccessor.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
                throw new AuthenticationException(AspectMessage.AuthenticationError);

            var userId = user.GetUserId();
            if (userId == 0)
                throw new AuthenticationException(AspectMessage.AuthenticationError);

            var userInfo = _loggedInUsers.UserInfo.FirstOrDefault(x => x.UserId == userId);
            if (userInfo != null)
                return;
            throw new SecurityException(AspectMessage.AccessDenied);

        }
    }
}
