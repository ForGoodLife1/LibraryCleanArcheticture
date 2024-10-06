namespace Library.Infrustructure.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string NameAr { get; set; } = null!;
    public string NameEn { get; set; } = null!;

    public string ContactInformation { get; set; } = null!;

    public string LibraryCardNumber { get; set; } = null!;

    public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
