using Library.Core.Features.UserCQRS.UserQueries.UserQueryResponses;
using Library.Infrustructure.Entities;

namespace Library.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserCQRSPaginatedListMapping()
        {

            CreateMap<User, GetUserCQRSPaginatedListResponse>();
        }
    }
}
