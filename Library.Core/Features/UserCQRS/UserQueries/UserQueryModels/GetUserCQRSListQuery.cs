using Library.Core.Bases;
using Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses;
using MediatR;

namespace Library.Core.Features.UserCQRS.UserQueries.UserQueryModels
{
    public class GetUserCQRSListQuery : IRequest<Response<List<GetUserCQRSListResponse>>>
    {

    }
}
