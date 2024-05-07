namespace GarageThree.Web.Services;

public class BaseMessageService : IMessageService
{
    public MessageViewModel GenerateMessage(IMessageParameters parameters)
    {
        return new MessageViewModel()
        {
            IsActive = parameters.IsActive,
            Type = parameters.Type,
            Text = parameters.Text
        };
    }
}