namespace GarageThree.Persistence.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garage>().ToTable("Garage");
            modelBuilder.Entity<Member>().ToTable("Member");

            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Vehicle>().Property(v => v.RegisteredAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<VehicleType>().ToTable("VehicleType");

            modelBuilder.Entity<Checkout>().ToTable("Checkout");
            modelBuilder.Entity<Checkout>().Property(c => c.TotalParkingCost).HasPrecision(14, 2);
            modelBuilder.Entity<Checkout>().Property(c => c.CheckoutAt)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd();
        }
    }
}