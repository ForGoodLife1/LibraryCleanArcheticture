using Library.Core.Bases;
using Library.Data.Requests;
using MediatR;

namespace Library.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest, IRequest<Response<string>>
    {
    }
}
