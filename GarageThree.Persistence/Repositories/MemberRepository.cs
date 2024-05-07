using GarageThree.Persistence.Data;
using GarageThree.Persistence.Parameters;

namespace GarageThree.Persistence.Repositories;

public class MemberRepository(ApplicationDbContext context) : IRepository<Member>
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Member> Create(Member entity)
    {
        var createdMember = await _context.Members.AddAsync(entity);
        await _context.SaveChangesAsync();
        return createdMember.Entity;
    }

    public async Task<Member?> Delete(int id)
    {
        var memberToDelete = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);
        if (memberToDelete != null)
        {
            var deletedMember = _context.Members.Remove(memberToDelete);
            await _context.SaveChangesAsync();
            return deletedMember.Entity;
        }
        return null;
    }

    public async Task<IEnumerable<Member>> GetAll()
    {
        var members = await _context.Members.ToListAsync();
        return members;
    }

    public async Task<bool> Any()
    {
        return await _context.Members.AnyAsync();
    }

    public async Task<Member?> GetById(int id)
    {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);
        return member;
    }

    public async Task<Member?> Update(Member entity)
    {
        var updatedMember = _context.Update(entity).Entity;
        await _context.SaveChangesAsync();
        return updatedMember;
    }

    public async Task<Member?> Single(QueryParams parameters)
    {
        var member = await _context.Members
                                    .FirstOrDefaultAsync(m => m.Id == (int?)parameters.Id || 
                                                    m.SSN == parameters.SSN);
        return member;
    }

    public Task<IEnumerable<Member>> Filter(QueryParams parameters)
    {
        throw new NotImplementedException();
    }
}