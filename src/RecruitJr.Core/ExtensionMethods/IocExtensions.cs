using RecruitJr.Core.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Interfaces.Helpers;
using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace RecruitJr.Core.ExtensionMethods
{
    public static class IocExtensions
    {
        public static void BindCommonServicesAsSingleton(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddSingleton<IPasswordHelper, PasswordHelper>()
                .AddSingleton<IJsonHelper, JsonHelper>();
        }
    }
}