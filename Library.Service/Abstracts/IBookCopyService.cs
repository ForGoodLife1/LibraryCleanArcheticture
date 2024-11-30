using Library.Infrustructure.Entities;

namespace Library.Service.Abstracts
{
    public interface IBookCopyService
    {
        public Task<BookCopy> GetBookCopyByIDWithIncludeAsync(int id);
        public Task<List<BookCopy>> GetListAsync();
        public Task<BookCopy> GetByIDAsync(int id);
        public Task<string> AddAsync(BookCopy bookCopy);
        public Task<string> EditAsync(BookCopy bookCopy);
        public Task<string> DeleteAsync(BookCopy bookCopy);
        public IQueryable<BookCopy> GetBookCopysQuerable();
    }
}
