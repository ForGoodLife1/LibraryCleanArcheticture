using Library.Data.Entities;
using Library.Infarastructure.InfrastructureBases;
using Library.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Library.Service.Implementations
{
    public class BookCopyService : IBookCopyService
    {
        #region Fields
        private readonly IGenericRepositoryAsync<BookCopy> _bookCopyRepository;
        #endregion

        #region constructors
        public BookCopyService(IGenericRepositoryAsync<BookCopy> bookCopyRepository)
        {
            _bookCopyRepository = bookCopyRepository;
        }


        #endregion
        #region Handle Functions


        public async Task<BookCopy> GetBookCopyByIDWithIncludeAsync(int id)
        {
            // var BookCopy = await _bookCopyRepository.GetByIdAsync(id);
            var BookCopy = _bookCopyRepository.GetTableNoTracking()
                                          .Include(x => x.Book)
                                          .Include(x => x.BorrowingRecords)
                                          .Include(x => x.Reservations)
                                          .Where(x => x.CopyId.Equals(id))
                                          .FirstOrDefault();
            return BookCopy;
        }

        public async Task<string> AddAsync(BookCopy BookCopy)
        {
            //Added BookCopy
            await _bookCopyRepository.AddAsync(BookCopy);
            return "Success";
        }


        public async Task<string> EditAsync(BookCopy BookCopy)
        {
            await _bookCopyRepository.UpdateAsync(BookCopy);
            return "Success";
        }

        public async Task<string> DeleteAsync(BookCopy BookCopy)
        {
            var trans = _bookCopyRepository.BeginTransaction();
            try
            {
                await _bookCopyRepository.DeleteAsync(BookCopy);
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

        public async Task<BookCopy> GetByIDAsync(int id)
        {
            var BookCopy = await _bookCopyRepository.GetByIdAsync(id);
            return BookCopy;
        }

        public IQueryable<BookCopy> GetBookCopysQuerable()
        {
            return _bookCopyRepository.GetTableNoTracking()
                                  .Include(x => x.BorrowingRecords)
                                  .Include(x => x.Book)
                                  .Include(x => x.Reservations).AsQueryable();
        }



        public async Task<List<BookCopy>> GetListAsync()
        {

            var result = await _bookCopyRepository.GetTableNoTracking()
                .Include(x => x.Reservations)
                .Include(x => x.BorrowingRecords)
                .Include(x => x.Book).ToListAsync();

            return result;
        }




        #endregion


    }
}