using MessageProvider.Api.MessageService.Models;

namespace MessageProvider.Api.Services;

public interface IMessageService
{
    Task SendNextMessageAsync(Message message);
    Task<Message> ReceiveNextMessage();
}
