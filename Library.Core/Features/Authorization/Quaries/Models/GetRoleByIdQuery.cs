using Library.Core.Bases;
using Library.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace Library.Core.Features.Authorization.Quaries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public int Id { get; set; }
    }
}
