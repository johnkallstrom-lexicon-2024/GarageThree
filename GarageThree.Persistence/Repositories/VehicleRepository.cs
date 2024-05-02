using GarageThree.Persistence.Data;

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
        var vehicles = await _context.Vehicles.ToListAsync();
        return vehicles;
    }

    public async Task<Vehicle?> GetById(int id)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        return vehicle;
    }

    public async Task<Vehicle?> Update(Vehicle entity)
    {
        var vehicleToUpdate = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == entity.Id);
        if (vehicleToUpdate != null)
        {
            // Which properties should be editable?
            vehicleToUpdate.Model = entity.Model;
            vehicleToUpdate.Brand = entity.Brand;
            vehicleToUpdate.Color = entity.Color;
            _context.Update(vehicleToUpdate);
            await _context.SaveChangesAsync();
            return vehicleToUpdate;
        }
        return null;
    }
}
