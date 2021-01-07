using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Jwt.Core.Utilities.Interceptors;
using System.Reflection;
using Module = Autofac.Module;

namespace Jwt.Business.Installers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var x = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(x).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
