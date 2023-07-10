using Microsoft.EntityFrameworkCore;
using MyBookStoreApp.MyBookStoreApp.Domain.Models;

namespace MyBookstoreApp.Infrastructure.DbContexts
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings and relationships here if needed
            // Example:
            // modelBuilder.Entity<Book>()
            //     .HasOne(b => b.Author)
            //     .WithMany(a => a.Books)
            //     .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
