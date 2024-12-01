using Library.Core.Bases;
using Library.Core.Features.Books.Queries.Responses;
using MediatR;

namespace Library.Core.Features.Books.Queries.Models
{
    public class GetBookByIDQuery : IRequest<Response<GetBookByIDResponse>>
    {
        public int Id { get; set; }
        public GetBookByIDQuery(int id)
        {
            Id = id;
        }
    }
}
