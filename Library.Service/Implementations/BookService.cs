using Library.Data.Entities;
using Library.Data.Enums;
using Library.Infarastructure.InfrastructureBases;
using Library.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Library.Service.Implementations
{
    public class BookService : IBookService
    {
        #region Fields
        private readonly IGenericRepositoryAsync<Book> _bookRepository;
        #endregion

        #region constructors
        public BookService(IGenericRepositoryAsync<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }


        #endregion
        #region Handle Functions


        public async Task<Book> GetBookByIDWithIncludeAsync(int id)
        {
            // var Book = await _bookRepository.GetByIdAsync(id);
            var Book = _bookRepository.GetTableNoTracking()
                                          .Include(x => x.BookCopies)
                                          .Where(x => x.BookId.Equals(id))
                                          .FirstOrDefault();
            return Book;
        }

        public async Task<string> AddAsync(Book Book)
        {
            //Added Book
            await _bookRepository.AddAsync(Book);
            return "Success";
        }

        public async Task<string> EditAsync(Book Book)
        {
            await _bookRepository.UpdateAsync(Book);
            return "Success";
        }

        public async Task<string> DeleteAsync(Book Book)
        {
            var trans = _bookRepository.BeginTransaction();
            try
            {
                await _bookRepository.DeleteAsync(Book);
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

        public async Task<Book> GetByIDAsync(int id)
        {
            var Book = await _bookRepository.GetByIdAsync(id);
            return Book;
        }

        public IQueryable<Book> GetBooksQuerable()
        {
            return _bookRepository.GetTableNoTracking()
                                  .Include(x => x.BookCopies).AsQueryable();
        }

        public IQueryable<Book> FilterBookPaginatedQuerable(BookOrderingEnum orderingEnum, string search)
        {
            var querable = GetBooksQuerable();
            if (search != null)
            {
                querable = querable.Where(x => x.Genre.Contains(search) || x.Title.Contains(search));
            }
            switch (orderingEnum)
            {
                case BookOrderingEnum.BookId:
                    querable = querable.OrderBy(x => x.BookId);
                    break;
                case BookOrderingEnum.Title:
                    querable = querable.OrderBy(x => x.Title);
                    break;
                case BookOrderingEnum.Genre:
                    querable = querable.OrderBy(x => x.Genre);
                    break;
                case BookOrderingEnum.PublicationDate:
                    querable = querable.OrderBy(x => x.PublicationDate);
                    break;

            }

            return querable;
        }
        public async Task<List<Book>> GetListAsync()
        {

            var result = await _bookRepository.GetTableNoTracking()
                .Include(x => x.BookCopies).ToListAsync();

            return result;
        }




        #endregion


    }
}