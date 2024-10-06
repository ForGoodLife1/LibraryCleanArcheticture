using Library.Core.Bases;
using Library.Data.Requests;
using MediatR;

namespace Library.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
