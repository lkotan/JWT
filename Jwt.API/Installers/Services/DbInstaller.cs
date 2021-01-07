using Jwt.Core.Repositories;
using Jwt.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jwt.API.Installers.Services
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JwtContext>(x => x.UseSqlServer(configuration.GetConnectionString("Jwt")), ServiceLifetime.Transient);
            services.AddTransient<JwtContext>();
            services.AddTransient<DbContext, JwtContext>();
        }

        public void InstallConfigure(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<JwtContext>();
            context.Database.Migrate();
        }

      
    }
}
