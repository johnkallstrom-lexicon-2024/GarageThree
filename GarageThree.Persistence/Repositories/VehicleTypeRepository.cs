using GarageThree.Persistence.Data;
using GarageThree.Persistence.Parameters;
using System.Linq.Expressions;

namespace GarageThree.Persistence.Repositories;

public class VehicleTypeRepository(ApplicationDbContext context) : IRepository<VehicleType>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<bool> Any()
    {
        return await _context.VehicleTypes.AnyAsync();
    }

    public bool Any(Func<Vehicle, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(Expression<Func<Vehicle, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleType> Create(VehicleType entity)
    {
        var createdVehicleType = await _context.VehicleTypes.AddAsync(entity);
        await _context.SaveChangesAsync();
        return createdVehicleType.Entity;
    }

    public async Task<VehicleType?> Delete(int id)
    {
        var vehicleTypeToDelete = await _context.VehicleTypes.FirstOrDefaultAsync(v => v.Id == id);
        if (vehicleTypeToDelete != null)
        {
            var deletedVehicleType = _context.VehicleTypes.Remove(vehicleTypeToDelete);
            await _context.SaveChangesAsync();
            return deletedVehicleType.Entity;
        }
        return null;
    }

    public async Task<IEnumerable<VehicleType>> Filter(QueryParams parameters)
    {
        var vehiclesTypes = _context.VehicleTypes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
        {
            vehiclesTypes = vehiclesTypes.Where(v =>
            v.Name.Contains(parameters.SearchTerm) ||
            v.NumberOfWheels.ToString().Contains(parameters.SearchTerm));
        }

        return await vehiclesTypes.ToListAsync();
    }

    public async Task<IEnumerable<VehicleType>> GetAll()
    {
        return await _context.VehicleTypes.ToListAsync();
    }

    public async Task<VehicleType?> GetById(int id)
    {
            return await _context.VehicleTypes.FirstOrDefaultAsync(v => v.Id == id);
    }

    public Task<VehicleType?> Single(QueryParams parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleType?> Update(VehicleType entity)
    {
        var updatedVehicleType = _context.Update(entity).Entity;
        await _context.SaveChangesAsync();
        return updatedVehicleType;
    }

    bool IRepository<VehicleType>.Any()
    {
        throw new NotImplementedException();
    }
}