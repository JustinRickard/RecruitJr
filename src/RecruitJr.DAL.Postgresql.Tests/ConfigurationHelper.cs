using System;
using RecruitJr.Core;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DAL.Postgresql.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace RecruitJr.DAL.Postgresql.Tests
{
    public static class ConfigurationHelper
    {
        public static ServiceProvider BuildServiceProvider() 
        {
            ServiceCollection services = new ServiceCollection();
            BindDependencies(services);

            return services.BuildServiceProvider();
        }

        private static void BindDependencies(ServiceCollection services) {         
            services.AddTransient<IClientRepository, ClientRepository>(); // TODO: Move this logic into DAL layer

            services
                .AddDbContext<RsPostgresContext>(
                    options => options.UseInMemoryDatabase("Test")
                );
        }
    }
}