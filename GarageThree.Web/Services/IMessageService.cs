namespace GarageThree.Web.Services;

public interface IMessageService
{
    public MessageViewModel Success(string message);
    public MessageViewModel Error(string message);
}