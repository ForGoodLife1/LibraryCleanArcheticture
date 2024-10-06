using Library.Service.Abstracts;
using Library.Service.AuthServices.Implementations;
using Library.Service.AuthServices.Interfaces;
using Library.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailsService, EmailsService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IFileService, FileService>();
            return services;

        }

    }
}
