using Library.Data.Entities;

namespace Library.Service.Abstracts
{
    public interface IBorrowingRecordService
    {
        public Task<BorrowingRecord> GetBorrowingRecordByIDWithIncludeAsync(int id);
        public Task<List<BorrowingRecord>> GetListAsync();
        public Task<BorrowingRecord> GetByIDAsync(int id);
        public Task<string> AddAsync(BorrowingRecord borrowingRecord);
        public Task<string> EditAsync(BorrowingRecord borrowingRecord);
        public Task<string> DeleteAsync(BorrowingRecord borrowingRecord);
        public IQueryable<BorrowingRecord> GetBorrowingRecordsQuerable();
    }
}
