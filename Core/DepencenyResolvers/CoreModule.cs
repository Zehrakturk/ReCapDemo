using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DepencenyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection servicesCollection)
        {
            servicesCollection.AddMemoryCache();
            servicesCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            servicesCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
