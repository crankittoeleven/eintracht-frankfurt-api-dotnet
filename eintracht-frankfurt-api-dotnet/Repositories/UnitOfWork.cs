using eintracht_frankfurt_api_dotnet.Models;

namespace eintracht_frankfurt_api_dotnet.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlayerContext _context;

        public IPlayerRepository<Player> Player { get; private set; }

        public UnitOfWork(PlayerContext context, IPlayerRepository<Player> player)
        {
            _context = context;
            Player = player;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
