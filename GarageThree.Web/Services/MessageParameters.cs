namespace GarageThree.Web.Services;

public class MessageParameters : IMessageParameters
{
    public MessageType Type { get; set; }
    public bool IsActive { get; set; }
    public string Text { get; set; } = default!;
}