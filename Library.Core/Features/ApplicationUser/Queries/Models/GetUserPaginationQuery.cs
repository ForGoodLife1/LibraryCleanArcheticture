using Library.Core.Features.ApplicationUser.Queries.Results;
using Library.Core.Wrappers;
using MediatR;

namespace Library.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationReponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
