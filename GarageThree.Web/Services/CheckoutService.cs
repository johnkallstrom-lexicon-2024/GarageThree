namespace GarageThree.Web.Services
{
    public class CheckoutService : ICheckoutService
    {
        private int _hourlyRate;
        private readonly IConfiguration _configuration;

        public CheckoutService(IConfiguration configuration)
        {
            _configuration = configuration;
            _hourlyRate = configuration.GetValue<int>("Garages:HourlyRate");
        }

        public TimeSpan CalculateParkingPeriod(DateTime parkedAt)
        {
            TimeSpan period = DateTime.Now - parkedAt;
            return period;
        }

        public decimal CalculateTotalParkingPrice(DateTime parkedAt)
        {
            TimeSpan period = CalculateParkingPeriod(parkedAt);
            int totalHours = (int)period.TotalHours;

            return totalHours * _hourlyRate;
        }
    }
}
