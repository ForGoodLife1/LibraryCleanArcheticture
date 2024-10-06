using FluentValidation;
using Library.Core.Features.Authorization.Commands.Models;
using Library.Core.Resources;
using Library.Service.Abstracts;
using Microsoft.Extensions.Localization;

namespace Library.Core.Features.Authorization.Commands.Validators
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public readonly IAuthorizationService _authorizationService;

        #endregion
        #region Constructors
        public DeleteRoleValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region  Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            //RuleFor(x => x.Id)
            //    .MustAsync(async (Key, CancellationToken) => await _authorizationService.IsRoleExistById(Key))
            //    .WithMessage(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
        }
        #endregion
    }
}
