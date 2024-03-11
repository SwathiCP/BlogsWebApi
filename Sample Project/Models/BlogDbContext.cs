using Microsoft.EntityFrameworkCore;

namespace Sample_Project.Models
{
    public class BlogDbContext : DbContext
    {

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) 
        { 
        }

        public DbSet<Blog> Blogs { get; set;}

        public DbSet<User> Users { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasKey(b => b.BId);
            // Add other configurations if needed
            modelBuilder.Entity<Blog>().HasKey(b => b.BId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
