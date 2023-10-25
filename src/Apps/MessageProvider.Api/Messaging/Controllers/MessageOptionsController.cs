using MessageProvider.Api.MessageService.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MessageProvider.Api.Messaging.Controllers;


[ApiController]
[Route("options")]
public class MessageOptionsController : ControllerBase
{
    private readonly MessageServiceOptions _options;

    public MessageOptionsController(IOptions<MessageServiceOptions> _options)
    {
        this._options = _options.Value;
    }

    [HttpGet]
    public ActionResult<MessageServiceOptions> GetOptions()
    {
        return Ok(_options);
    }
}
