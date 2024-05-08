namespace GarageThree.Web.Services;

public class BaseMessageService : IMessageService
{
    public MessageViewModel Error(string message)
    {
        return new MessageViewModel()
        {
            IsActive = true,
            Text = message,
            Type = MessageType.Danger
        };
    }

    public MessageViewModel Success(string message)
    {
        return new MessageViewModel()
        {
            IsActive = true,
            Text = message,
            Type = MessageType.Success
        };
    }
}