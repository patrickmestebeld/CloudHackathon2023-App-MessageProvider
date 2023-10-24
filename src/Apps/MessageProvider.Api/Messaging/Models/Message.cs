namespace MessageProvider.Api.MessageService.Models;

public class Message
{
    public Message() : this("")
    {
    }

    public Message(string content)
    {
        Content = content;
    }

    //public int Id { get; set; }
    // public string Sender { get; set; }
    // public string Recipient { get; set; }
    public string Content { get; set; }
}
