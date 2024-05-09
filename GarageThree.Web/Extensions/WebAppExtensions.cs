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

    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddTransient<IRepository<Vehicle>, VehicleRepository>();
        services.AddTransient<IRepository<Garage>, GarageRepository>();
        services.AddTransient<IRepository<Member>, MemberRepository>();
        services.AddTransient<IRepository<VehicleType>, VehicleTypeRepository>();
        services.AddTransient<IRepository<Checkout>, CheckoutRepository>();
        services.AddTransient<IMessageService, BaseMessageService>();

        services.AddTransient<ISortService<Member>, MemberSortService>();

        services.AddTransient<ISelectListItemService<Garage>, GarageSelectListItemService>();
        services.AddTransient<ISelectListItemService<Member>, MemberSelectListItemService>();
        services.AddTransient<ISelectListItemService<VehicleType>, VehicleTypeSelectListItemService>();

        services.AddAutoMapper(config =>
        {
            config.AddProfile<GarageProfile>();
            config.AddProfile<MemberProfile>();
            config.AddProfile<VehicleProfile>();
            config.AddProfile<VehicleTypeProfile>();
            config.AddProfile<CheckoutProfile>();
        });

        return services;
    }
}
