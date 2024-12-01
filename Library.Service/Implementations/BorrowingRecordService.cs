using Library.Data.Entities;
using Library.Infarastructure.InfrastructureBases;
using Library.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Library.Service.Implementations
{
    public class BorrowingRecordService : IBorrowingRecordService
    {
        #region Fields
        private readonly IGenericRepositoryAsync<BorrowingRecord> _borrowingRecordRepository;
        #endregion

        #region constructors
        public BorrowingRecordService(IGenericRepositoryAsync<BorrowingRecord> borrowingRecordRepository)
        {
            _borrowingRecordRepository = borrowingRecordRepository;
        }


        #endregion
        #region Handle Functions


        public async Task<BorrowingRecord> GetBorrowingRecordByIDWithIncludeAsync(int id)
        {
            // var BorrowingRecord = await _borrowingRecordRepository.GetByIdAsync(id);
            var BorrowingRecord = _borrowingRecordRepository.GetTableNoTracking()
                                          .Include(x => x.Copy)
                                          .Include(x => x.User)
                                          .Where(x => x.BorrowingRecordId.Equals(id))
                                          .FirstOrDefault();
            return BorrowingRecord;
        }

        public async Task<string> AddAsync(BorrowingRecord BorrowingRecord)
        {
            //Added BorrowingRecord
            await _borrowingRecordRepository.AddAsync(BorrowingRecord);
            return "Success";
        }



        public async Task<string> EditAsync(BorrowingRecord BorrowingRecord)
        {
            await _borrowingRecordRepository.UpdateAsync(BorrowingRecord);
            return "Success";
        }

        public async Task<string> DeleteAsync(BorrowingRecord BorrowingRecord)
        {
            var trans = _borrowingRecordRepository.BeginTransaction();
            try
            {
                await _borrowingRecordRepository.DeleteAsync(BorrowingRecord);
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

        public async Task<BorrowingRecord> GetByIDAsync(int id)
        {
            var BorrowingRecord = await _borrowingRecordRepository.GetByIdAsync(id);
            return BorrowingRecord;
        }

        public IQueryable<BorrowingRecord> GetBorrowingRecordsQuerable()
        {
            return _borrowingRecordRepository.GetTableNoTracking()
                                  .Include(x => x.Copy)
                                  .Include(x => x.User).AsQueryable();
        }



        public async Task<List<BorrowingRecord>> GetListAsync()
        {

            var result = await _borrowingRecordRepository.GetTableNoTracking()
                .Include(x => x.Copy)
                .Include(x => x.User).ToListAsync();

            return result;
        }




        #endregion


    }
}