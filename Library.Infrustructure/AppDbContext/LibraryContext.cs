using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Library.Data.Entities.Identity;
using Library.Infrustructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrustructure.AppDbContext;

public partial class LibraryContext : IdentityDbContext<IdUser, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    private readonly IEncryptionProvider _encryptionProvider;

    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
        _encryptionProvider=new GenerateEncryptionProvider("8a4dcaaec64d412380fe4b02193cd26f");

    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCopy> BookCopies { get; set; }

    public virtual DbSet<BorrowingRecord> BorrowingRecords { get; set; }

    public virtual DbSet<Fine> Fines { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<IdUser> IdUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5RPLH84\\SQLEXPRESS;Initial Catalog=Library;Integrated Security=SSPI;TrustServerCertificate=true ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C2276D984D44");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<BookCopy>(entity =>
        {
            entity.HasKey(e => e.CopyId).HasName("PK__BookCopi__C26CCCE57EB9A8F4");

            entity.Property(e => e.CopyId).HasColumnName("CopyID");
            entity.Property(e => e.BookId).HasColumnName("BookID");

            entity.HasOne(d => d.Book).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookCopie__BookI__398D8EEE");
        });

        modelBuilder.Entity<BorrowingRecord>(entity =>
        {
            entity.HasKey(e => e.BorrowingRecordId).HasName("PK__Borrowin__D7C457FC843EDA3E");

            entity.Property(e => e.BorrowingRecordId).HasColumnName("BorrowingRecordID");
            entity.Property(e => e.CopyId).HasColumnName("CopyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Copy).WithMany(p => p.BorrowingRecords)
                .HasForeignKey(d => d.CopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Borrowing__CopyI__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.BorrowingRecords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Borrowing__UserI__3E52440B");
        });

        modelBuilder.Entity<Fine>(entity =>
        {
            entity.HasKey(e => e.FineId).HasName("PK__Fines__9D4A9BCC946078AE");

            entity.Property(e => e.FineId).HasColumnName("FineID");
            entity.Property(e => e.BorrowingRecordId).HasColumnName("BorrowingRecordID");
            entity.Property(e => e.FineAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.BorrowingRecord).WithMany(p => p.Fines)
                .HasForeignKey(d => d.BorrowingRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fines_BorrowingRecords");

            entity.HasOne(d => d.User).WithMany(p => p.Fines)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fines__UserID__4222D4EF");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F040DE82C50");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.CopyId).HasColumnName("CopyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Copy).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__CopyI__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__4F7CD00D");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC23B1124F");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.NameAr).HasMaxLength(100);
            entity.Property(e => e.NameEn).HasMaxLength(100);
            entity.Property(e => e.ContactInformation).HasMaxLength(255);
            entity.Property(e => e.LibraryCardNumber).HasMaxLength(50);

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
