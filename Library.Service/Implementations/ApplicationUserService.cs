using Library.Data.Entities.Identity;
using Library.Infrustructure.AppDbContext;
using Library.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        #region Fields
        private readonly UserManager<IdUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailsService _emailsService;
        private readonly LibraryContext _applicationDBContext;
        private readonly IUrlHelper _urlHelper;
        #endregion
        #region Constructors
        public ApplicationUserService(UserManager<IdUser> userManager,
                                      IHttpContextAccessor httpContextAccessor,
                                      IEmailsService emailsService,
                                      LibraryContext applicationDBContext,
                                      IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            _applicationDBContext = applicationDBContext;
            _urlHelper = urlHelper;
        }
        #endregion
        #region Handle Functions
        public async Task<string> AddUserAsync(IdUser iduser, string password)
        {
            var trans = await _applicationDBContext.Database.BeginTransactionAsync();
            try
            {
                //if Email is Exist
                var existUser = await _userManager.FindByEmailAsync(iduser.Email);
                //email is Exist
                if (existUser != null) return "EmailIsExist";

                //if username is Exist
                var userByUserName = await _userManager.FindByNameAsync(iduser.UserName);
                //username is Exist
                if (userByUserName != null) return "UserNameIsExist";
                //Create
                var createResult = await _userManager.CreateAsync(iduser, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

                await _userManager.AddToRoleAsync(iduser, "User");

                //Send Confirm Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(iduser);
                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme + "://" + resquestAccessor.Host + _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = iduser.Id, code = code });
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Link Of Confirmation</a>";
                //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                //message or body
                await _emailsService.SendEmail(iduser.Email, message, "ConFirm Email");

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }

        }
        #endregion
    }
}
