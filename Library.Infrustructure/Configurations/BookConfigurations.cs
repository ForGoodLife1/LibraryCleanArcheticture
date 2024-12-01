using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.BookId).HasName("PK__Books__3DE0C2276D984D44");

            builder.Property(e => e.BookId).HasColumnName("BookID");
            builder.Property(e => e.Genre).HasMaxLength(50);
            builder.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            builder.Property(e => e.Title).HasMaxLength(255);

        }
    }
}
