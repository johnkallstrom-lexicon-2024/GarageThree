namespace GarageThree.Web.Services;

public interface ISortService<T> where T : class
{
    public Task<IQueryable<T>> Sort(IEnumerable<T> query);
}