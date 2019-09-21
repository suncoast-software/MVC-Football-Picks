using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Football_Picks.Models;

namespace MVC_Football_Picks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Matchup> Matchups { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerPicks> PlayerPicks { get; set; }
        public DbSet<MVC_Football_Picks.Models.MatchupWinner> MatchupWinner { get; set; }
    }
}
