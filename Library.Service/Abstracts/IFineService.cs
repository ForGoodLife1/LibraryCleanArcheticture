using Library.Infrustructure.Entities;

namespace Library.Service.Abstracts
{
    public interface IFineService
    {
        public Task<Fine> GetFineByIDWithIncludeAsync(int id);
        public Task<List<Fine>> GetListAsync();
        public Task<Fine> GetByIDAsync(int id);
        public Task<string> AddAsync(Fine fine);
        public Task<string> EditAsync(Fine fine);
        public Task<string> DeleteAsync(Fine fine);
        public IQueryable<Fine> GetFinesQuerable();
        public IQueryable<Fine> FilterFinePaginatedQuerable(string search);
    }
}
