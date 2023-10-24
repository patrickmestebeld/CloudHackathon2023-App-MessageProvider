using Azure.Messaging.ServiceBus;
using MessageProvider.Api.MessageService.Options;
using MessageProvider.Api.Services;
using Microsoft.Extensions.Options;

namespace MessageProvider.Api.MessageService.Impl;

public class MessageService : IMessageService
{
    private readonly string _connectionString;
    private readonly string _queueName;

    public MessageService(IOptions<MessageServiceOptions> options)
    {
        _connectionString = options.Value.ConnectionString;
        _queueName = options.Value.QueueName;
    }

    public async Task SendNextMessageAsync(Models.Message message)
    {
        await using var client = new ServiceBusClient(_connectionString);
        ServiceBusSender sender = client.CreateSender(_queueName);
        await sender.SendMessageAsync(new Azure.Messaging.ServiceBus.ServiceBusMessage(message.Content));
    }

    public async Task<Models.Message> ReceiveNextMessage()
    {
        await using var client = new ServiceBusClient(_connectionString);
        ServiceBusReceiver receiver = client.CreateReceiver(_queueName);
        return await receiver.ReceiveMessageAsync().ContinueWith(sbm => new Models.Message(sbm.Result.Body.ToString()));
    }
}