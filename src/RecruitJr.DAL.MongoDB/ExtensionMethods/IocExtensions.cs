using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DAL.MongoDB.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace RecruitJr.DAL.MongoDB.ExtensionMethods
{
    public static class IocExtensions
    {
        public static void BindRepositoriesAsSingleton(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddSingleton<IAuditRepository, AuditRepository>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IClientRepository, ClientRepository>()
                .AddSingleton<IProjectRepository, ProjectRepository>()
                .AddSingleton<IWorkflowRepository, WorkflowRepository>()
                .AddSingleton<IWorkflowStepRepository, WorkflowStepRepository>()
                .AddSingleton<IWorkflowStepItemRepository, WorkflowStepItemRepository>();                
        }

        public static void BindRepositoriesAsTransient(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddTransient<IAuditRepository, AuditRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IClientRepository, ClientRepository>()
                .AddTransient<IProjectRepository, ProjectRepository>()                
                .AddTransient<IWorkflowRepository, WorkflowRepository>()
                .AddTransient<IWorkflowStepRepository, WorkflowStepRepository>()
                .AddTransient<IWorkflowStepItemRepository, WorkflowStepItemRepository>();
        }
    }
}