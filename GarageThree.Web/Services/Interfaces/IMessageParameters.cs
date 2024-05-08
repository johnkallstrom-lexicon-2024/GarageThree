namespace GarageThree.Web.Services.Interfaces;

public interface IMessageParameters
{
    public bool IsActive { get; set; }
    public MessageType Type { get; set; }
    public string Text { get; set; }
}