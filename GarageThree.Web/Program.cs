var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddTransient<IRepository<Vehicle>, VehicleRepository>();
builder.Services.AddTransient<IRepository<Garage>, GarageRepository>();
builder.Services.AddTransient<IRepository<Member>, MemberRepository>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<GarageProfile>();
    config.AddProfile<MemberProfile>();
    config.AddProfile<VehicleProfile>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "DevContainers")
{
    app.UseDeveloperExceptionPage();

    // Suggest we keep this outcommented, otherwise the db will be deleted, rebuilt and inserted with new data everytime the application starts
    // Uncomment this line when you need to rebuild and seed your database
    //await app.SeedDataAsync();
}

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Members}/{action=Index}/{id?}");

app.Run();
