using Library.Infrustructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Configurations
{
    public class FineConfigurations : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.HasKey(e => e.FineId).HasName("PK__Fines__9D4A9BCC946078AE");

            builder.Property(e => e.FineId).HasColumnName("FineID");
            builder.Property(e => e.BorrowingRecordId).HasColumnName("BorrowingRecordID");
            builder.Property(e => e.FineAmount).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.UserId).HasColumnName("UserID");

            builder.HasOne(d => d.BorrowingRecord).WithMany(p => p.Fines)
                .HasForeignKey(d => d.BorrowingRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fines_BorrowingRecords");

            builder.HasOne(d => d.User).WithMany(p => p.Fines)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fines__UserID__4222D4EF");
        }
    }
}
