namespace Library.Infrustructure.Entities;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int UserId { get; set; }

    public int CopyId { get; set; }

    public DateOnly ReservationDate { get; set; }

    public virtual BookCopy Copy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
