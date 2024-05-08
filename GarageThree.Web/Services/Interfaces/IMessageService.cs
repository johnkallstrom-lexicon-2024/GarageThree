namespace GarageThree.Web.Services.Interfaces;

public interface IMessageService
{
    public MessageViewModel Success(string message);
    public MessageViewModel Error(string message);
}