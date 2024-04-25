using System.Linq.Expressions;

namespace eintracht_frankfurt_api_dotnet.Repositories
{
    public interface IPlayerRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
