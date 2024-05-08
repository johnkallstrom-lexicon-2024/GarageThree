using Bogus;
using Bogus.Extensions.Sweden;
using GarageThree.Persistence.Repositories;
using Vehicle = GarageThree.Core.Entities.Vehicle;

namespace GarageThree.Persistence.Data;

public class SeedData(IRepository<Garage> garageRepository,
                    IRepository<Vehicle> vehicleRepository,
                    IRepository<Member> memberRepository
                    )
{
    private readonly IRepository<Garage> _garageRepository = garageRepository;
    private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;
    private readonly IRepository<Member> _memberRepository = memberRepository;
    private readonly Faker _faker = new("sv");

    private readonly List<Garage> _garages = [];
    private readonly List<Vehicle> _vehicles = [];
    private readonly List<Member> _members = [];
    private readonly List<VehicleType> _vehicleTypes = [];
    private readonly Random _rnd = new();

    public async Task InitAsync()
    {
        bool garagesExist = await _garageRepository.AnyAsync();
        bool vehiclesExist = await _vehicleRepository.AnyAsync();
        bool membersExist = await _memberRepository.AnyAsync();

        if (garagesExist || vehiclesExist || membersExist) return;

        GenerateVehicleTypes(5);
        GenerateGarages(5);
        GenerateMembers(50);
        GenerateVehicles(50);

        foreach (var g in _garages)
        {
            await _garageRepository.Create(g);
        }

        foreach (var m in _members)
        {
            await _memberRepository.Create(m);
        }

        foreach (var v in _vehicles)
        {
            await _vehicleRepository.Create(v);
        }
    }

    private void GenerateVehicleTypes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            VehicleType vehicleType = new()
            {
                Name = _faker.Vehicle.Type(),
                NumberOfWheels = _rnd.Next(0, 10),
            };
            _vehicleTypes.Add(vehicleType);
        }
    }

    private void GenerateGarages(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Garage garageToCreate = new()
            {
                Name = $"Garage-{i + 1}",
                Capacity = _rnd.Next(10, 250),
                HourlyRate = new Random().Next(10, 30)
            };
            _garages.Add(garageToCreate);
        }
    }

    private void GenerateVehicles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var vehicleType = _faker.PickRandom(_vehicleTypes);
            var member = _faker.PickRandom(_members);
            var garage = _faker.PickRandom(_garages);

            Vehicle vehicleToCreate = new()
            {
                RegNumber = _faker.Vehicle.Vin(),
                RegisteredAt = _faker.Date.Between(DateTime.Now, DateTime.Now.AddDays(-7)),
                Brand = _faker.Vehicle.Manufacturer(),
                Model = _faker.Vehicle.Model(),
                Color = _faker.PickRandom<Color>(),
                VehicleTypeId = vehicleType.Id,
                VehicleType = vehicleType,
                GarageId = garage.Id,
                Garage = garage,
                MemberId = member.Id,
                Member = member
            };
            _vehicles.Add(vehicleToCreate);
        }
    }

    private void GenerateMembers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Member memberToCreate = new()
            {
                Avatar = _faker.Internet.Avatar(),
                FirstName = _faker.Name.FirstName(),
                LastName = _faker.Name.LastName(),
                Age = _rnd.Next(18, 100),
                Email = _faker.Internet.Email(),
                Username = _faker.Internet.UserName(),
                SSN = _faker.Person.Personnummer(),

            };
            _members.Add(memberToCreate);
        }
    }
}