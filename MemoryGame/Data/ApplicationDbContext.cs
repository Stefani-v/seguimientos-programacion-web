using MemoryGame.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameResult> GameResults { get; set; }
    }
}

