using Library.Data.Entities;
using Library.Infrastructure.InfrastructureBases;
using Library.Infrustructure.Abstracts;
using Library.Infrustructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrustructure.Repositories
{
    public class UserRepository : GenericRepositoryAsync<User>, IUserRepository
    {
        #region Fields
        private readonly DbSet<User> _user;
        #endregion
        #region Constructors
        public UserRepository(LibraryContext dBContext) : base(dBContext)
        {
            _user = dBContext.Set<User>();
        }

        #endregion
    }
}
