using GarageThree.Persistence.Data;

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
        var memberToDelete = await _context.Members.FirstOrDefaultAsync(v => v.Id == id);
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
        var member = await _context.Members.FirstOrDefaultAsync(v => v.Id == id);
        return member;
    }

    public async Task<Member?> Update(Member entity)
    {
        var memberToUpdate = await _context.Members.FirstOrDefaultAsync(v => v.Id == entity.Id);
        if (memberToUpdate != null)
        {
            // Which properties should be editable?
            memberToUpdate.FirstName = entity.FirstName;
            memberToUpdate.LastName = entity.LastName;
            memberToUpdate.Email = entity.Email;
            memberToUpdate.Avatar = entity.Avatar;
            memberToUpdate.Username = entity.Username;
            _context.Update(memberToUpdate);
            await _context.SaveChangesAsync();
            return memberToUpdate;
        }
        return null;
    }
}
