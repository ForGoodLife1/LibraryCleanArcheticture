namespace Library.Infrustructure.Entities;

public partial class BorrowingRecord
{
    public int BorrowingRecordId { get; set; }

    public int UserId { get; set; }

    public int CopyId { get; set; }

    public DateOnly BorrowingDate { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? ActualReturnDate { get; set; }

    public virtual BookCopy Copy { get; set; } = null!;

    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    public virtual User User { get; set; } = null!;
}
