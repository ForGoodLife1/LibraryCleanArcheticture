using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.Books.Queries.Models
{
    public class GetBookPaginatedListQuery : IRequest<Response<GetBookPaginatedListResponse>>
    {
    }
}
