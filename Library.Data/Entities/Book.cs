namespace Library.Data.Entities;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; }

    public string Isbn { get; set; }

    public DateOnly PublicationDate { get; set; }

    public string Genre { get; set; }

    public string? AdditionalDetails { get; set; }

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
}
