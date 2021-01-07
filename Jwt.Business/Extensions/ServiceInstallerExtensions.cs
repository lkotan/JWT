using Jwt.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Business.Extensions
{
    public static class ServiceInstallerExtensions
    {
        public static void InstallBusinessServices(this IServiceCollection service)
        {
            ServiceTool.Create(service);
        }
    }
}
