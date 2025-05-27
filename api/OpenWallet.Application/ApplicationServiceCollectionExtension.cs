using Microsoft.Extensions.DependencyInjection;
using OpenWallet.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
