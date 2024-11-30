using Library.Core.Bases;
using MediatR;

namespace Library.Core.Features.Books.Queries.Models
{
    public class GetBookListQuery : IRequest<Response<GetBookListResponse>>
    {
    }
}
