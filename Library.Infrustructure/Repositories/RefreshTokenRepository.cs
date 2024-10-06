using Library.Data.Entities.Identity;
using Library.Infrastructure.InfrastructureBases;
using Library.Infrustructure.Abstracts;
using Library.Infrustructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrustructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private DbSet<UserRefreshToken> userRefreshToken;
        #endregion

        #region Constructors
        public RefreshTokenRepository(LibraryContext dbContext) : base(dbContext)
        {
            userRefreshToken=dbContext.Set<UserRefreshToken>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
