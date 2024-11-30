using Library.Infarastructure.InfrastructureBases;
using Library.Infrustructure.Entities;
using Library.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Library.Service.Implementations
{
    public class FineService : IFineService
    {
        #region Fields
        private readonly IGenericRepositoryAsync<Fine> _fineRepository;
        #endregion

        #region constructors
        public FineService(IGenericRepositoryAsync<Fine> fineRepository)
        {
            _fineRepository = fineRepository;
        }


        #endregion
        #region Handle Functions


        public async Task<Fine> GetFineByIDWithIncludeAsync(int id)
        {
            // var Fine = await _fineRepository.GetByIdAsync(id);
            var Fine = _fineRepository.GetTableNoTracking()
                                          .Include(x => x.BorrowingRecord)
                                          .Include(x => x.User)
                                          .Where(x => x.FineId.Equals(id))
                                          .FirstOrDefault();
            return Fine;
        }

        public async Task<string> AddAsync(Fine Fine)
        {
            //Added Fine
            await _fineRepository.AddAsync(Fine);
            return "Success";
        }

        public async Task<string> EditAsync(Fine Fine)
        {
            await _fineRepository.UpdateAsync(Fine);
            return "Success";
        }

        public async Task<string> DeleteAsync(Fine Fine)
        {
            var trans = _fineRepository.BeginTransaction();
            try
            {
                await _fineRepository.DeleteAsync(Fine);
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

        public async Task<Fine> GetByIDAsync(int id)
        {
            var Fine = await _fineRepository.GetByIdAsync(id);
            return Fine;
        }

        public IQueryable<Fine> GetFinesQuerable()
        {
            return _fineRepository.GetTableNoTracking()
                                  .Include(x => x.BorrowingRecord)
                                  .Include(x => x.User).AsQueryable();
        }

        public IQueryable<Fine> FilterFinePaginatedQuerable(string search)
        {
            var querable = GetFinesQuerable();
            if (search != null)
            {
                querable = querable.Where(x => x.NumberOfLateDays.Equals(search) || x.PaymentStatus.Equals(search));
            }
            return querable;

        }
        public async Task<List<Fine>> GetListAsync()
        {

            var result = await _fineRepository.GetTableNoTracking()
                .Include(x => x.BorrowingRecord)
                .Include(x => x.User).ToListAsync();

            return result;
        }




        #endregion


    }
}