using Microsoft.Extensions.DependencyInjection;
using RecruitJr.DB.Seed.Common.Seeders;

namespace RecruitJr.DB.Seed.Common.ExtensionMethods
{
    public static class IocExtensions
    {
        public static void BindSeeders(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddSingleton<Seeder>()
                .AddSingleton<UserSeeder>();
        }
    }
}