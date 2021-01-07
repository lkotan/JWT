using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Core.Utilities.IoC
{
    public interface IModule
    {
        void Load(IServiceCollection collection);
    }
}
