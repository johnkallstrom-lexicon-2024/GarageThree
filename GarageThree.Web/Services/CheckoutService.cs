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
            TimeSpan period = parkedAt - DateTime.Now;
            return period;
        }

        public decimal CalculateTotalParkingPrice(DateTime parkedAt)
        {
            decimal price = (parkedAt - DateTime.Now).Hours * _hourlyRate;
            return price;
        }
    }
}
