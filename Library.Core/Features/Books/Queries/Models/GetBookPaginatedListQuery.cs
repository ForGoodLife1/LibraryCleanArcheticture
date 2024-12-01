using Library.Core.Features.Books.Queries.Responses;
using Library.Core.Wrappers;
using Library.Data.Enums;
using MediatR;

namespace Library.Core.Features.Books.Queries.Models
{
    public class GetBookPaginatedListQuery : IRequest<PaginatedResult<GetBookPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public BookOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
