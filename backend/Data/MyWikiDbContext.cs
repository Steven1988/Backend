
using fullstackApp.Models;
using Microsoft.EntityFrameworkCore;

namespace fullstackApp.Data
{
    public class MyWikiDbContext : DbContext
    {
        public MyWikiDbContext(DbContextOptions<MyWikiDbContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<NoteTags>()
                .HasKey(n => new { n.NoteId, n.TagId });
        }
    }
}