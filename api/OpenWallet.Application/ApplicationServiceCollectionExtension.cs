using Microsoft.Extensions.DependencyInjection;
using OpenWallet.Application.Database;
using OpenWallet.Application.Repositories;
using OpenWallet.Application.Services;
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
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountCategoryRepository, AccountCategoryRepository>();
            return services;
        }

        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<DbInitializer>(); 
            return services;
        }
    }
}
