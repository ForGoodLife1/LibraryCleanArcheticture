using Library.Data.Enums;
using Library.Infrustructure.Entities;

namespace Library.Service.Abstracts
{
    public interface IBookService
    {
        public Task<Book> GetBookByIDWithIncludeAsync(int id);
        public Task<List<Book>> GetListAsync();
        public Task<Book> GetByIDAsync(int id);
        public Task<string> AddAsync(Book book);
        public Task<string> EditAsync(Book book);
        public Task<string> DeleteAsync(Book book);
        public IQueryable<Book> GetBooksQuerable();
        public IQueryable<Book> FilterBookPaginatedQuerable(BookOrderingEnum orderingEnum, string search);
    }
}
