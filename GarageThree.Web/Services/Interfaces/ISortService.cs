namespace GarageThree.Web.Services.Interfaces;

public interface ISortService<T> where T : class
{
    public Task<IQueryable<T>> Sort(IEnumerable<T> query);
}