using Library.Data.Entities;
using Library.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Library.Infrustructure.AppDbContext;

public partial class LibraryContext : IdentityDbContext<IdUser, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    // private readonly IEncryptionProvider _encryptionProvider;

    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
        // _encryptionProvider=new GenerateEncryptionProvider("8a4dcaaec64d412380fe4b02193cd26f");

    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCopy> BookCopies { get; set; }

    public virtual DbSet<BorrowingRecord> BorrowingRecords { get; set; }

    public virtual DbSet<Fine> Fines { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<IdUser> IdUsers { get; set; }
    public DbSet<UserRefreshToken> UserRefreshToken { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.UseEncryption(_encryptionProvider);


    }
}
