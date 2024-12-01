using Library.Core.Bases;
using Library.Core.Features.Books.Queries.Responses;
using MediatR;

namespace Library.Core.Features.Books.Queries.Models
{
    public class GetBookListQuery : IRequest<Response<List<GetBookListResponse>>>
    {
    }
}
