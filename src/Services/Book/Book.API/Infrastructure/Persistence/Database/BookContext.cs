using Microsoft.EntityFrameworkCore;

namespace Book.API;

public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new BookEntityTypeConfiguration())
            .ApplyConfiguration(new PublisherEntityTypeConfiguration());
    }
}