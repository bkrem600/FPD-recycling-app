using Microsoft.EntityFrameworkCore;


namespace UWS.Shared
{
    public class CompanyX : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<FPD> FPDs { get; set; }

        public CompanyX(DbContextOptions<CompanyX> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            //define primary key for Categories table
            modelBuilder.Entity<Category>()
            .HasKey(c => new { c.CategoryID });

            modelBuilder.Entity<Category>()
            .Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(30);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
            .HasMany(c => c.FPDs)
            .WithOne(f => f.Category);

            //define primary key for FPDs table
            modelBuilder.Entity<FPD>()
            .HasKey(f => f.ID);

            modelBuilder.Entity<FPD>()
            .Property(f => f.Size);

            modelBuilder.Entity<FPD>()
            .Property(f => f.Make)
            .IsRequired()
            .HasMaxLength(50);

            modelBuilder.Entity<FPD>()
            .Property(f => f.ModelCode)
            .IsRequired()
            .HasMaxLength(50);

            modelBuilder.Entity<FPD>()
            .HasIndex(f => f.ModelCode)
            .IsUnique();

            // modelBuilder.Entity<FPD>()
            // .HasAlternateKey(f => f.ModelCode);

            modelBuilder.Entity<FPD>()
            .Property(f => f.Origin)
            .HasMaxLength(30);

            modelBuilder.Entity<FPD>()
            .Property(f => f.FrontCasingSorting)
            .HasMaxLength(20);

            modelBuilder.Entity<FPD>()
            .Property(f => f.BackCasingSorting)
            .HasMaxLength(20);

            //define foreign key CategoryID
            modelBuilder.Entity<FPD>()
            .HasOne(f => f.Category)
            .WithMany(c => c.FPDs)
            .IsRequired().HasForeignKey(f => f.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FPD>().ToTable("FPDs");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }
    }
}