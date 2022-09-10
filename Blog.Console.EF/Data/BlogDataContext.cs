using Blog.Console.EF.Data.Mappings;
using Blog.Console.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Console.EF.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostWithTagCount> PostsWithTagCounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());

            //Just an example of how to map a view or pure queries
            modelBuilder.Entity<PostWithTagCount>(x =>
            {
                x.ToSqlQuery(@"
                        SELECT
                             [Title] AS [Name],
                              SELECT COUNT {[Id]) FROM [Tags] WHERE [PostId] = [Id]
                                   AS [Count]
                        FROM [Posts]");
            });
        }
    }
}
