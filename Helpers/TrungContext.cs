using Microsoft.EntityFrameworkCore;
using gcsharpRPC.Models;

namespace gcsharpRPC.Helpers
{
    public class TrungContext : DbContext
    {
        // Dependedency Injection
        protected readonly IConfiguration Configuration;

        public TrungContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poll>()
                .HasMany(x => x.UserVotes)
                .WithOne(x => x.Poll);
            modelBuilder.Entity<UserVote>()
                .HasMany(x => x.Options)
                .WithMany(x => x.UserVotes);
        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<UserVote> UserVotes { get; set; }
    }
}