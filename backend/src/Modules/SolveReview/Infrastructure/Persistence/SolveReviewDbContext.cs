using backend.src.Modules.SolveReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview.Infrastructure.Persistence
{
    public class SolveReviewDbContext : DbContext  
    {
        public SolveReviewDbContext(DbContextOptions<SolveReviewDbContext> options)
            : base(options)
        {
        }
        public DbSet<Solve> Solves { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define constraints and relationships if needed
            modelBuilder.Entity<Solve>()
                .HasIndex(p => p.UserId); // Index for faster queries
        }
    }
}