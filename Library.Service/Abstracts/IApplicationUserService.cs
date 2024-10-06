using Library.Data.Entities.Identity;

namespace Library.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(IdUser idUser, string password);
    }
}
