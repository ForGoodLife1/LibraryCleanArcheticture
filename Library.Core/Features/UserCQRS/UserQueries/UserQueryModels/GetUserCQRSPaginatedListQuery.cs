using Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses;
using Library.Core.Wrappers;
using Library.Data.Enums;
using MediatR;

namespace Library.Core.Features.UserCQRS.UserQueries.UserQueryModels
{
    public class GetUserCQRSPaginatedListQuery : IRequest<PaginatedResult<GetUserCQRSPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public UserOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
