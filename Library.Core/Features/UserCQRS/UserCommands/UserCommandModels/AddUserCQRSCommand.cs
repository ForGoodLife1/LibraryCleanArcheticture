using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.UserCQRS.UserCommands.UserCommandModels
{
    public class AddUserCQRSCommand : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string ContactInformation { get; set; }
        public string LibraryCardNumber { get; set; }
    }
}
