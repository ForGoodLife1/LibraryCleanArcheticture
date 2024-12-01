using FluentValidation;
using Library.Core.Features.Books.Commands.Models;
using Library.Core.Resources;
using Library.Service.Abstracts;
using Microsoft.Extensions.Localization;

namespace Library.Core.Features.Books.Commands.Validatiors
{
    public class AddBookValidatior : AbstractValidator<AddBookCommand>
    {
        #region Fields
        private readonly IBookService _BookService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Constructors
        public AddBookValidatior(IBookService BookService,
                                   IStringLocalizer<SharedResources> localizer)

        {
            _BookService = BookService;
            _localizer = localizer;
            ApplyValidationsRules();

        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Isbn)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
            RuleFor(x => x.AdditionalDetails)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
               .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
            RuleFor(x => x.Genre)
               .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
               .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);


        }
        #endregion
    }
}
