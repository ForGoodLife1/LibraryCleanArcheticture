namespace Library.Data.Entities;

public partial class Fine
{
    public int FineId { get; set; }
    public short? NumberOfLateDays { get; set; }
    public decimal? FineAmount { get; set; }
    public bool? PaymentStatus { get; set; }

    public int BorrowingRecordId { get; set; }
    public virtual BorrowingRecord? BorrowingRecord { get; set; }

    public int UserId { get; set; }
    public virtual User? User { get; set; }
}
