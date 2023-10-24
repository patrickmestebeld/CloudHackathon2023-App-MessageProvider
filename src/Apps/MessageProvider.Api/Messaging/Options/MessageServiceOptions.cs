namespace MessageProvider.Api.MessageService.Options;

public class MessageServiceOptions
{
    public const string Name = "MessageServiceOptions";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string ConnectionString { get; set; }
    public string QueueName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
