namespace GarageThree.Web
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
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
            });

            return services;
        }
    }
}
