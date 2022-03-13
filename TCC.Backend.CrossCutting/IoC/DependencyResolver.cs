using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TCC.Backend.Domain.Repositories;
using TCC.Backend.Domain.Repositories.Base;
using TCC.Backend.Infrastructure.Repositories;
using TCC.Backend.Infrastructure.Repositories.Base;

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
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IDbAccessHelper, DbAccessHelper>();
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
        }
    }
}