using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Configurations
{
    public class BookCopyConfigurations : IEntityTypeConfiguration<BookCopy>
    {
        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            builder.HasKey(e => e.CopyId).HasName("PK__BookCopi__C26CCCE57EB9A8F4");

            builder.Property(e => e.CopyId).HasColumnName("CopyID");
            builder.Property(e => e.BookId).HasColumnName("BookID");

            builder.HasOne(d => d.Book).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookCopie__BookI__398D8EEE");

        }
    }
}
