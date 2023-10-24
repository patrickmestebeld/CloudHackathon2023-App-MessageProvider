using MessageProvider.Api.MessageService.Models;
using MessageProvider.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageProvider.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMessage()
    {
        var message = await _messageService.ReceiveNextMessage();
        return Ok(message);
    }

    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] string message)
    {
        await _messageService.SendNextMessageAsync(new Message(message));
        return Ok();
    }
}
