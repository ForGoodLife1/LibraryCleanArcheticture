using Library.Data.Entities.Identity;
using Library.Data.Requests;
using Library.Data.Results;
namespace Library.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExistByName(string roleName);
        public Task<string> EditRoleAsync(EditRoleRequest request);
        public Task<string> DeleteRoleAsync(int roleId);
        public Task<bool> IsRoleExistById(int roleId);
        public Task<List<Role>> GetRolesList();
        public Task<Role> GetRoleById(int id);
        public Task<ManageUserRolesResult> ManageUserRolesData(IdUser iduser);
        public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);
        public Task<ManageUserClaimsResult> ManageUserClaimData(IdUser iduser);
        public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);
    }
}
