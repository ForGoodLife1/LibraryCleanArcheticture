using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.Books.Queries.Models
{
    internal class GetBookByIDQuery : IRequest<Response<GetBookByIDResponse>>
    {
    }
}
