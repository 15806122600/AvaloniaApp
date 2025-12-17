using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AvaloniaApp.Messages;

public class UpdateTotalsMessage(string value) : ValueChangedMessage<string>(value)
{
}
