using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OpenWallet.Application.Database;
using OpenWallet.Application.Repositories;
using OpenWallet.Application.Services;

namespace OpenWallet.Application
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountCategoryRepository, AccountCategoryRepository>();
            services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
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
