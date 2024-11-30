using Library.Infrustructure.Entities;

namespace Library.Service.Abstracts
{
    public interface IReservationService
    {
        public Task<Reservation> GetReservationByIDWithIncludeAsync(int id);
        public Task<List<Reservation>> GetListAsync();
        public Task<Reservation> GetByIDAsync(int id);
        public Task<string> AddAsync(Reservation reservation);
        public Task<string> EditAsync(Reservation reservation);
        public Task<string> DeleteAsync(Reservation reservation);
        public IQueryable<Reservation> GetReservationsQuerable();
    }
}
