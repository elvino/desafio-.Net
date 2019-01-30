using Application.Services;
using Application.Services.Interfaces;
using Domain.Data.Commands.Handlers;
using Domain.Data.Interfaces;
using Infra.Data.Transactions;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Cutting
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<UserHandler, UserHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
