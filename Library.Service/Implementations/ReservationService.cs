using Library.Infarastructure.InfrastructureBases;
using Library.Infrustructure.Entities;
using Library.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Library.Service.Implementations
{
    public class ReservationService : IReservationService
    {
        #region Fields
        private readonly IGenericRepositoryAsync<Reservation> _reservationRepository;
        #endregion

        #region constructors
        public ReservationService(IGenericRepositoryAsync<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }


        #endregion
        #region Handle Functions


        public async Task<Reservation> GetReservationByIDWithIncludeAsync(int id)
        {
            // var Reservation = await _reservationRepository.GetByIdAsync(id);
            var reservation = _reservationRepository.GetTableNoTracking()
                                          .Include(x => x.Copy)
                                          .Include(x => x.User)
                                          .Where(x => x.ReservationId.Equals(id))
                                          .FirstOrDefault();
            return reservation;
        }

        public async Task<string> AddAsync(Reservation reservation)
        {
            //Added Reservation
            await _reservationRepository.AddAsync(reservation);
            return "Success";
        }



        public async Task<string> EditAsync(Reservation Reservation)
        {
            await _reservationRepository.UpdateAsync(Reservation);
            return "Success";
        }

        public async Task<string> DeleteAsync(Reservation Reservation)
        {
            var trans = _reservationRepository.BeginTransaction();
            try
            {
                await _reservationRepository.DeleteAsync(Reservation);
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

        public async Task<Reservation> GetByIDAsync(int id)
        {
            var Reservation = await _reservationRepository.GetByIdAsync(id);
            return Reservation;
        }

        public IQueryable<Reservation> GetReservationsQuerable()
        {
            return _reservationRepository.GetTableNoTracking()
                                   .Include(x => x.Copy)
                                   .Include(x => x.User).AsQueryable();
        }
        public async Task<List<Reservation>> GetListAsync()
        {

            var result = await _reservationRepository.GetTableNoTracking()
                                                    .Include(x => x.Copy)
                                                    .Include(x => x.User).ToListAsync();

            return result;
        }




        #endregion


    }
}