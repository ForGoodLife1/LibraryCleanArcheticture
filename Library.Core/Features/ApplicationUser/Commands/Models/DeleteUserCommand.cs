using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
