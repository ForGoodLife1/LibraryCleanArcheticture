using FluentValidation;
using Library.Core.Features.UserCQRS.UserCommands.UserCommandModels;
using Library.Core.Resources;
using Library.Service.Abstracts;
using Microsoft.Extensions.Localization;

namespace Library.Core.Features.UserCQRS.UserCommands.UserCommandValidatiors
{
    public class AddUserCQRSValidator : AbstractValidator<AddUserCQRSCommand>
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Constructors
        public AddUserCQRSValidator(IUserService userService,
                                   IStringLocalizer<SharedResources> localizer)

        {
            _userService = userService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.ContactInformation)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
            RuleFor(x => x.LibraryCardNumber)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
               .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);


        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (Key, CancellationToken) => !await _userService.IsNameArExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _userService.IsNameEnExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);




        }

        #endregion

    }
}
