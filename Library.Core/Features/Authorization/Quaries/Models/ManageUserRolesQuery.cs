using Library.Core.Bases;
using Library.Data.Results;
using MediatR;

namespace Library.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResult>>
    {
        public int UserId { get; set; }
    }
}
