using GarageThree.Persistence.Data;
using GarageThree.Persistence.Parameters;
using System.Linq.Expressions;

namespace GarageThree.Persistence.Repositories
{
    public class CheckoutRepository(ApplicationDbContext context) : IRepository<Checkout>
    {
        private readonly ApplicationDbContext _context = context;

        public bool Any()
        {
            throw new NotImplementedException();
        }

        public bool Any(Func<Checkout, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Checkout, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Checkout> Create(Checkout entity)
        {
            var entry = await _context.Checkouts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public Task<Checkout?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Checkout>> Filter(QueryParams parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Checkout>> GetAll()
        {
            var checkouts = await _context.Checkouts
                .Include(c => c.Member)
                .ToListAsync();

            return checkouts;
        }

        public async Task<Checkout?> GetById(int id)
        {
            var checkout = await _context.Checkouts
                .Include(c => c.Member)
                .FirstOrDefaultAsync(c => c.Id == id);

            return checkout;
        }

        public Task<Checkout?> Single(QueryParams parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Checkout?> Update(Checkout entity)
        {
            throw new NotImplementedException();
        }
    }
}
