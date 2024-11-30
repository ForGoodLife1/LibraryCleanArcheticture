namespace Library.Data.Entities;

public partial class BorrowingRecord
{
    public int BorrowingRecordId { get; set; }
    public DateOnly BorrowingDate { get; set; }
    public DateOnly DueDate { get; set; }
    public DateOnly? ActualReturnDate { get; set; }

    public int CopyId { get; set; }
    public virtual BookCopy? Copy { get; set; }

    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

}
