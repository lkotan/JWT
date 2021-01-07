using Microsoft.Extensions.DependencyInjection;
using Jwt.Core.Utilities.IoC;
using Jwt.Core.Repositories;
using Jwt.Core.Repositories.EF;
using Jwt.Core.Plugins.Authentication.Jwt;
using Jwt.Core.Plugins.Authentication;
using System.Diagnostics;

namespace Jwt.Core.Extensions
{
    public static class ServiceInstallerExtensions
    {
        public static void InstallCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddSingleton<IActiveUserService, UserJwtService>();
            services.AddSingleton<Stopwatch>();

            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<,>));
            services.AddTransient(typeof(IDataAccessRepository<>), typeof(EfDataAccessRepository<>));
            ServiceTool.Create(services);
        }
    }
}