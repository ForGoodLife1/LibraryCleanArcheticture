using Library.Core.Bases;
using Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses;
using MediatR;

namespace Library.Core.Features.UserCQRS.UserQueries.UserQueryModels
{
    public class GetUserCQRSByIDQuery : IRequest<Response<GetUserCQRSByIDResponse>>
    {
        public int Id { get; set; }
        public GetUserCQRSByIDQuery(int id)
        {
            Id = id;
        }
    }
}
