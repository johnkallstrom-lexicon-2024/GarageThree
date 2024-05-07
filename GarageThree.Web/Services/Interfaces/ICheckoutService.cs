namespace GarageThree.Web.Services.Interfaces
{
    public interface ICheckoutService
    {
        int GetGarageHourlyRate();
        TimeSpan CalculateParkingPeriod(DateTime parkedAt);
        decimal CalculateTotalParkingPrice(DateTime parkedAt);
    }
}
