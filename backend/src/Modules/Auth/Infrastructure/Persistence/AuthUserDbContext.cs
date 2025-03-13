using backend.src.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.Auth.Infrastructure.Persistence
{
    public class AuthUserDbContext : DbContext
    {
        public AuthUserDbContext(DbContextOptions<AuthUserDbContext> options) : base(options) {

        }
        public DbSet<AuthUser> AuthUsers {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.HasKey(e => e.ZitadelUserId);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
            });
        }
    }
}