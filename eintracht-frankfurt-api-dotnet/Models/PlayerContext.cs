using Microsoft.EntityFrameworkCore;

namespace eintracht_frankfurt_api_dotnet.Models
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Player> Players { get; set; }
    }
}
