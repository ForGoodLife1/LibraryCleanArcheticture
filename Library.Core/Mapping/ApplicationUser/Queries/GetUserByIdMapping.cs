using Library.Core.Features.ApplicationUser.Queries.Results;
using Library.Data.Entities.Identity;

namespace Library.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
