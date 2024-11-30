using Library.Data.Commons;

namespace Library.Data.Entities;

public partial class User : GeneralLocalizableEntity
{
    public int UserId { get; set; }

    public string? NameAr { get; set; }
    public string? NameEn { get; set; }

    public string? ContactInformation { get; set; }

    public string? LibraryCardNumber { get; set; }

    public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
