using GarageThree.Persistence.Data;
using GarageThree.Persistence.Parameters;
using System.Linq.Expressions;

namespace GarageThree.Persistence.Repositories;

public class GarageRepository(ApplicationDbContext context) : IRepository<Garage>
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Garage> Create(Garage entity)
    {
        var createdGarage = await _context.Garages.AddAsync(entity);
        await _context.SaveChangesAsync();
        return createdGarage.Entity;
    }

    public async Task<Garage?> Delete(int id)
    {
        var garageToDelete = await _context.Garages.FirstOrDefaultAsync(v => v.Id == id);
        if (garageToDelete != null)
        {
            var deletedGarage = _context.Garages.Remove(garageToDelete);
            await _context.SaveChangesAsync();
            return deletedGarage.Entity;
        }
        return null;
    }

    public async Task<bool> AnyAsync()
    {
        return await _context.Garages.AnyAsync();
    }

    public async Task<IEnumerable<Garage>> GetAll()
    {
        return await _context.Garages
                             .Include(g => g.Vehicles)
                             .ToListAsync();
    }

    public async Task<Garage?> GetById(int id)
    {
        var garage = await _context.Garages
                                   .Include(g => g.Vehicles )
                                   .FirstOrDefaultAsync(g => g.Id == id);
        return garage;
    }

    public async Task<Garage?> Update(Garage entity)
    {
        var updatedGarage = _context.Update(entity).Entity;
        await _context.SaveChangesAsync();
        return updatedGarage;
    }

    public Task<IEnumerable<Garage>> Filter(QueryParams parameters)
    {
        throw new NotImplementedException();
    }

    public Task<Garage?> Single(QueryParams parameters)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(Expression<Func<Vehicle, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public bool Any()
    {
        throw new NotImplementedException();
    }

    public bool Any(Func<Vehicle, bool> predicate)
    {
        throw new NotImplementedException();
    }
}