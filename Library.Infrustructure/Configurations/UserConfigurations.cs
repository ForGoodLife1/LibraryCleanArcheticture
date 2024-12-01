using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrustructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC23B1124F");

            builder.Property(e => e.UserId).HasColumnName("UserID");
            builder.Property(e => e.NameAr).HasMaxLength(100);
            builder.Property(e => e.NameEn).HasMaxLength(100);
            builder.Property(e => e.ContactInformation).HasMaxLength(255);
            builder.Property(e => e.LibraryCardNumber).HasMaxLength(50);
        }
    }
}
