using Library.Core.Bases;
using Library.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace Library.Core.Features.Authorization.Quaries.Models
{
    public class GetRolesListQuery : IRequest<Response<List<GetRolesListResult>>>
    {
    }
}
