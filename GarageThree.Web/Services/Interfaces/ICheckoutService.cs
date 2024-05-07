namespace GarageThree.Web.Services.Interfaces
{
    public interface ICheckoutService
    {
        TimeSpan CalculateParkingPeriod(DateTime parkedAt);
        decimal CalculateTotalParkingPrice(DateTime parkedAt);
    }
}
