using MessageProvider.Api.MessageService.Models;
using MessageProvider.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageProvider.Api.Messaging.Controllers;


[ApiController]
[Route("events")]
public class MessageEventController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageEventController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMessageEvent()
    {
        var message = await _messageService.ReceiveNextMessage();
        return Ok(message);
    }

    [HttpPost]
    public async Task<IActionResult> PostMessageEvent([FromBody] string message)
    {
        await _messageService.SendNextMessageAsync(new Message(message));
        return Ok();
    }
}
