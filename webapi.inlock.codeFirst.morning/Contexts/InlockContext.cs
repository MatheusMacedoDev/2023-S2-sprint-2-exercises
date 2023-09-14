using Microsoft.EntityFrameworkCore;
using webapi.inlock.codeFirst.morning.Domain;

namespace webapi.inlock.codeFirst.morning.Contexts
{
    public class InlockContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        // Server = NOTE17-S14; Database = inlock_games_db_morning_auto; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True
        // Data Source = NOTE17-S14; Initial Catalog = inlock_games_db_morning_auto; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer("Server = NOTE17-S14; Database = inlock_games_db_morning_auto; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True");
      
    }
}
