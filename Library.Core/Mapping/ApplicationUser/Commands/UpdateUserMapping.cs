using Library.Core.Features.ApplicationUser.Commands.Models;
using Library.Data.Entities.Identity;

namespace Library.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<EditUserCommand, IdUser>();
        }
    }
}
