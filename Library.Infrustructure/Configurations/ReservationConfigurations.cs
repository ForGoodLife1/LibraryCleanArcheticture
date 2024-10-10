using Library.Infrustructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Configurations
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F040DE82C50");

            builder.Property(e => e.ReservationId).HasColumnName("ReservationID");
            builder.Property(e => e.CopyId).HasColumnName("CopyID");
            builder.Property(e => e.UserId).HasColumnName("UserID");

            builder.HasOne(d => d.Copy).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__CopyI__5070F446");

            builder.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__4F7CD00D");

        }
    }
}
