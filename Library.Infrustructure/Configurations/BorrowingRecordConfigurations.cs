using Library.Infrustructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Configurations
{
    public class BorrowingRecordConfigurations : IEntityTypeConfiguration<BorrowingRecord>
    {
        public void Configure(EntityTypeBuilder<BorrowingRecord> builder)
        {
            builder.HasKey(e => e.BorrowingRecordId).HasName("PK__Borrowin__D7C457FC843EDA3E");

            builder.Property(e => e.BorrowingRecordId).HasColumnName("BorrowingRecordID");
            builder.Property(e => e.CopyId).HasColumnName("CopyID");
            builder.Property(e => e.UserId).HasColumnName("UserID");

            builder.HasOne(d => d.Copy).WithMany(p => p.BorrowingRecords)
                .HasForeignKey(d => d.CopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Borrowing__CopyI__3F466844");

            builder.HasOne(d => d.User).WithMany(p => p.BorrowingRecords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Borrowing__UserI__3E52440B");

        }
    }
}
