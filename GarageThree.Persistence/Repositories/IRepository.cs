using GarageThree.Persistence.Parameters;
using System.Linq.Expressions;

namespace GarageThree.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    public Task<T> Create(T entity);
    public Task<T?> Delete(int id);
    public Task<T?> GetById(int id);
    bool Any();
    bool Any(Func<T, bool> predicate);
    public Task<bool> AnyAsync();
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    public Task<IEnumerable<T>> GetAll();
    public Task<IEnumerable<T>> Filter(QueryParams parameters);
    public Task<T?> Single(QueryParams parameters);
    public Task<T?> Update(T entity);
}