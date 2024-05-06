using GarageThree.Persistence.Parameters;

namespace GarageThree.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    public Task<T> Create(T entity);
    public Task<T?> Delete(int id);
    public Task<T?> GetById(int id);
    public Task<bool> Any();
    public Task<IEnumerable<T>> GetAll();
    public Task<IEnumerable<T>> Filter(QueryParams parameters);
    public Task<T?> Update(T entity);
}