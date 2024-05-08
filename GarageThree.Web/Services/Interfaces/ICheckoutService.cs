namespace GarageThree.Web.Services.Interfaces
{
    public interface ICheckoutService
    {
        int GetHourlyRate();
        TimeSpan CalculateParkingPeriod(DateTime parkedAt);
        decimal CalculateTotalParkingPrice(DateTime parkedAt);
    }
}
