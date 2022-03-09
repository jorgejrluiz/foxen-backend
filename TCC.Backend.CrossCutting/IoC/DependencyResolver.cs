using Microsoft.Extensions.DependencyInjection;
using TCC.Backend.Application;
using TCC.Backend.Application.Interfaces;
using TCC.Backend.Domain.Repositories;
using TCC.Backend.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace TCC.Backend.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IClienteApplication, ClienteApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}