using Library.Data.Enums;
using Library.Infrustructure.Abstracts;
using Library.Infrustructure.Entities;
using Library.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Library.Service.Implementations
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region constructors
        public UserService(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }


        #endregion
        #region Handle Functions


        public async Task<User> GetUserByIDWithIncludeAsync(int id)
        {
            // var User = await _userRepository.GetByIdAsync(id);
            var user = _userRepository.GetTableNoTracking()
                                          .Include(x => x.BorrowingRecords)
                                          .Include(x => x.Fines)
                                          .Include(x => x.Reservations)
                                          .Where(x => x.UserId.Equals(id))
                                          .FirstOrDefault();
            return user;
        }

        public async Task<string> AddAsync(User user)
        {
            //Added User
            await _userRepository.AddAsync(user);
            return "Success";
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            //Check if the name is Exist Or not
            var user = _userRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr)).FirstOrDefault();
            if (user == null) return false;
            return true;
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            //Check if the name is Exist Or not
            var user = await _userRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) & !x.UserId.Equals(id)).FirstOrDefaultAsync();
            if (user == null) return false;
            return true;
        }

        public async Task<string> EditAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            return "Success";
        }

        public async Task<string> DeleteAsync(User user)
        {
            var trans = _userRepository.BeginTransaction();
            try
            {
                await _userRepository.DeleteAsync(user);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }

        }

        public async Task<User> GetByIDAsync(int id)
        {
            var User = await _userRepository.GetByIdAsync(id);
            return User;
        }

        public IQueryable<User> GetUsersQuerable()
        {
            return _userRepository.GetTableNoTracking()
                                  .Include(x => x.BorrowingRecords)
                                  .Include(x => x.Fines)
                                  .Include(x => x.Reservations).AsQueryable();
        }

        public IQueryable<User> FilterUserPaginatedQuerable(UserOrderingEnum orderingEnum, string search)
        {
            var querable = GetUsersQuerable();
            if (search != null)
            {
                querable = querable.Where(x => x.NameAr.Contains(search) || x.LibraryCardNumber.Contains(search));
            }
            switch (orderingEnum)
            {
                case UserOrderingEnum.UserId:
                    querable = querable.OrderBy(x => x.UserId);
                    break;
                case UserOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.NameAr);
                    break;
                case UserOrderingEnum.LibraryCardNumber:
                    querable = querable.OrderBy(x => x.LibraryCardNumber);
                    break;

            }

            return querable;
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            //Check if the name is Exist Or not
            var User = _userRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (User == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            //Check if the name is Exist Or not
            var User = await _userRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn) & !x.UserId.Equals(id)).FirstOrDefaultAsync();
            if (User == null) return false;
            return true;
        }

        public async Task<List<User>> GetListAsync()
        {

            var result = await _userRepository.GetTableNoTracking()
                .Include(x => x.BorrowingRecords).Include(x => x.Fines)
                .Include(x => x.Reservations).ToListAsync();

            return result;
        }




        #endregion


    }
}