using RecruitJr.Core.Dto;
using RecruitJr.Core.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Models;
using RecruitJr.Core.Security;
using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using RecruitJr.Core.Services;
using RecruitJr.Core.Interfaces.Services;

namespace RecruitJr.Core.ExtensionMethods
{
    public static class IocExtensions
    {
        public static void BindCommonServicesAsSingleton(this IServiceCollection serviceProvider) {
            serviceProvider
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<IPasswordHelper, PasswordHelper>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher>()
                .AddSingleton<IJsonHelper, JsonHelper>()
                .AddSingleton<IAuditHelper, AuditHelper>()
                .AddSingleton<UserManager<User>>()
                .AddSingleton<IUserStore<User>, UserStore>()
                .AddSingleton<IRoleStore<Role>, RoleStore>()
                .AddSingleton<ILookupNormalizer, LookupNormalizer>()
                .AddSingleton<IdentityErrorDescriber>();
        }
    }
}