using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.UserCQRS.UserCommands.UserCommandModels
{
    public class DeleteUserCQRSCommand : IRequest<Response<string>>
    {
        public DeleteUserCQRSCommand(int userId)
        {
            UserId=userId;
        }

        public int UserId { get; set; }

    }
}
