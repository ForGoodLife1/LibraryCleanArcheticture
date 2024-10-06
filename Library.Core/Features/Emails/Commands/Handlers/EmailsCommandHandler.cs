using Library.Core.Bases;
using Library.Core.Features.Emails.Commands.Models;
using Library.Core.Resources;
using Library.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
namespace Library.Core.Features.Emails.Commands.Handlers
{
    public class EmailsCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IEmailsService _emailsService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public EmailsCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                    IEmailsService emailsService) : base(stringLocalizer)
        {
            _emailsService= emailsService;
            _stringLocalizer= stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailsService.SendEmail(request.Email, request.Message, null);
            if (response=="Success")
                return Success<string>("");
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.SendEmailFailed]);
        }
        #endregion
    }
}
