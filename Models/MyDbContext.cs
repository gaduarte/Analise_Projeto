using Microsoft.EntityFrameworkCore;
using biblioteca_trabalho.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Alert> Alerts { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Books> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração de relacionamento para a entidade Books
        modelBuilder.Entity<Books>()
            .HasOne(b => b.Member)
            .WithMany(m => m.Books)
            .HasForeignKey(b => b.MemberId);

        // Configuração de relacionamento para a entidade Librarian
        modelBuilder.Entity<Librarian>()
            .HasOne(l => l.Alert)
            .WithOne(a => a.Librarian)
            .HasForeignKey<Alert>(a => a.LibrarianId)
            .IsRequired(false);

        // Configuração de relacionamento para outras entidades Member
        modelBuilder.Entity<Student>()
            .ToTable("Student");

        modelBuilder.Entity<FacultyMember>()
            .ToTable("FacultyMember");

        // Configuração para mapear RefrenceBook para uma tabela separada
        modelBuilder.Entity<RefrenceBook>()
            .ToTable("RefrenceBooks");

        // Configuração para mapear GeneralBook para uma tabela separada
        modelBuilder.Entity<GeneralBook>()
            .ToTable("GeneralBooks");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<biblioteca_trabalho.Models.RefrenceBook> RefrenceBook { get; set; }

    public DbSet<biblioteca_trabalho.Models.Student> Student { get; set; }

    public DbSet<biblioteca_trabalho.Models.GeneralBook> GeneralBook { get; set; }

    public DbSet<biblioteca_trabalho.Models.FacultyMember> FacultyMember { get; set; }
}



