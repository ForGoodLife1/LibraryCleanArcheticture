using Library.Core.Features.Authorization.Quaries.Results;
using Library.Data.Entities.Identity;

namespace Library.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<Role, GetRoleByIdResult>();
        }
    }
}
