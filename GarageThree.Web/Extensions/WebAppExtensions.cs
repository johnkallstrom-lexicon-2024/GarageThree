using GarageThree.Persistence.Data;
using GarageThree.Persistence.Repositories;
using GarageThree.Core.Entities;

namespace GarageThree.Web.Extensions;

public static class WebAppExtensions
{

    public static async Task SeedDataAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var garageRepository = serviceProvider.GetService<IRepository<Garage>>();
        var vehicleRepository = serviceProvider.GetService<IRepository<Vehicle>>();
        var memberRepository = serviceProvider.GetService<IRepository<Member>>();

        SeedData seedData = new(garageRepository!, vehicleRepository!, memberRepository!);

        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();

        try
        {
            await seedData.InitAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
