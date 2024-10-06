using Library.Core.Bases;
using Library.Data.Results;
using MediatR;

namespace Library.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
