using LabManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LabManagementSystem.Data
{
    public class LabMgmtDbContext : DbContext
    {
        public LabMgmtDbContext(DbContextOptions<LabMgmtDbContext> dbContextOptions) : base(dbContextOptions)
        { 
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Lab> Lab { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").UseSequence();
                entity.Property(e => e.FirstName).HasColumnName("First_Name");
                entity.Property(e => e.LastName).HasColumnName("Last_Name");
            });
            

            modelBuilder.Entity<Category>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").UseSequence();
                entity.Property(e => e.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<Lab>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").UseSequence();
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.AuthorId).HasColumnName("Author_ID");
                entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            });
            //modelBuilder.Entity<Lab>().HasOne(p =>p.Author).WithMany(s => s.Labs).HasForeignKey(p => p.AuthorId);
        }
    }
}