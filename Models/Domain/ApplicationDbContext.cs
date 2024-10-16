using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models.Domain
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }
        
        // The class which will be a table in the DB (domain class)
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
