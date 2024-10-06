using Library.Core.Bases;
using Library.Data.Requests;
using MediatR;

namespace Library.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleRequest, IRequest<Response<string>>
    {

    }
}
