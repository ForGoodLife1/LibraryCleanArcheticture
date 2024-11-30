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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IFineService, FineService>();
            services.AddTransient<IBorrowingRecordService, BorrowingRecordService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookCopyService, BookCopyService>();
            return services;

        }

    }
}
