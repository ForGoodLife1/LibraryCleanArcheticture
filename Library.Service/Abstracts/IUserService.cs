using Library.Data.Entities;
using Library.Data.Enums;

namespace Library.Service.Abstracts
{
    public interface IUserService
    {
        public Task<User> GetUserByIDWithIncludeAsync(int id);
        public Task<List<User>> GetListAsync();
        public Task<User> GetByIDAsync(int id);
        public Task<string> AddAsync(User user);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(User user);
        public Task<string> DeleteAsync(User user);
        public IQueryable<User> GetUsersQuerable();
        public IQueryable<User> FilterUserPaginatedQuerable(UserOrderingEnum orderingEnum, string search);
    }
}
