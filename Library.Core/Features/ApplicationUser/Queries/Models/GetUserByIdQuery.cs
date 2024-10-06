using Library.Core.Bases;
using Library.Core.Features.ApplicationUser.Queries.Results;
using MediatR;

namespace Library.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
