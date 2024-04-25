using eintracht_frankfurt_api_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eintracht_frankfurt_api_dotnet.Repositories
{
    public class PlayerRepository : IPlayerRepository<Player>
    {
        protected PlayerContext context;
        internal DbSet<Player> dbSet;

        public PlayerRepository(PlayerContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Player>();
        }

        public async Task<Player> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Add(Player entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Update(Player entity)
        {
            var existing = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            existing.FullName = entity.FullName;
            existing.Country = entity.Country;
            existing.BirthYear = entity.BirthYear;
        }

        public async Task<IEnumerable<Player>> Find(Expression<Func<Player, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task Delete(int id)
        {
            var existing = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

            dbSet.Remove(existing);
        }
    }
}
