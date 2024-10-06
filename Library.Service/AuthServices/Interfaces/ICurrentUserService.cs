using Library.Data.Entities.Identity;

namespace Library.Service.AuthServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<IdUser> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
