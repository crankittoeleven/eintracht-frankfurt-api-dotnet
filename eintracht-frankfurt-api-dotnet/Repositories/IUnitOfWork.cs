using eintracht_frankfurt_api_dotnet.Models;

namespace eintracht_frankfurt_api_dotnet.Repositories
{
    public interface IUnitOfWork
    {
        IPlayerRepository<Player> Player { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
