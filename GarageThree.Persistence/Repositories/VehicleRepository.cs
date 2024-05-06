using GarageThree.Persistence.Data;
using GarageThree.Persistence.Parameters;

namespace GarageThree.Persistence.Repositories;

public class VehicleRepository(ApplicationDbContext context) : IRepository<Vehicle>
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Vehicle> Create(Vehicle entity)
    {
        var createdVehicle = await _context.Vehicles.AddAsync(entity);
        await _context.SaveChangesAsync();
        return createdVehicle.Entity;
    }

    public async Task<Vehicle?> Delete(int id)
    {
        var vehicleToDelete = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        if (vehicleToDelete != null)
        {
            var deletedVehicle = _context.Vehicles.Remove(vehicleToDelete);
            await _context.SaveChangesAsync();
            return deletedVehicle.Entity;
        }
        return null;
    }

    public async Task<bool> Any()
    {
        return await _context.Vehicles.AnyAsync();
    }

    public async Task<IEnumerable<Vehicle>> GetAll()
    {
        var vehicles = await _context.Vehicles
            .Include(v => v.VehicleType)
            .Include(v => v.Garage)
            .ToListAsync();

        return vehicles;
    }

    public async Task<Vehicle?> GetById(int id)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        return vehicle;
    }

    public async Task<Vehicle?> Update(Vehicle entity)
    {
            var updatedVehicle = _context.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return updatedVehicle;
    }

    public async Task<IEnumerable<Vehicle>> Filter(QueryParams parameters)
    {
        var vehicles = _context.Vehicles
            .Include(v => v.VehicleType)
            .Include(v => v.Garage) as IQueryable<Vehicle>;

        int? garageId = (int?)parameters.Id;
        if (garageId.HasValue)
        {
            vehicles = vehicles.Where(v => v.GarageId == garageId.Value);
        }

        return await vehicles.ToListAsync();
    }
}