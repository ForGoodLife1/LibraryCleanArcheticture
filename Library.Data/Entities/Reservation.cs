namespace Library.Data.Entities;

public partial class Reservation
{
    public int ReservationId { get; set; }
    public DateOnly ReservationDate { get; set; }

    public int CopyId { get; set; }
    public virtual BookCopy? Copy { get; set; }

    public int UserId { get; set; }
    public virtual User? User { get; set; }
}
