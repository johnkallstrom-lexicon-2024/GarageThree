using GarageThree.Web.ViewModels.Enums;

namespace GarageThree.Web.ViewModels.Message;

public class MessageViewModel
{
    public bool IsActive { get; set; }
    public MessageType Type { get; set; }
    public string Text { get; set; } = default!;
}