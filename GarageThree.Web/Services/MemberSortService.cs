namespace GarageThree.Web.Services;

public class MemberSortService : ISortService<Member>
{
    public async Task<IQueryable<Member>> Sort(IEnumerable<Member> query)
    {
        var sortedMembers = await Task.Run(() =>
        {
            return query.OrderBy(m => m.FirstName[..2], StringComparer.Ordinal);
        });
        return sortedMembers.AsQueryable();
    }
}