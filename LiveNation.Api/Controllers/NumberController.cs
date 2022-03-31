namespace LiveNation.Api.Controllers;

using LiveNation.Api.Services;
using LiveNation.Core;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/number")]
public class NumberController : ControllerBase
{
    private readonly ILogger<NumberController> _logger;
    private readonly INumberService _numberService;

    public NumberController(
        ILogger<NumberController> logger,
        INumberService lnService
        )
    {
        _logger = logger;
        _numberService = lnService;
    }

    [HttpGet]
    [Route("processrange")]
    public ActionResult<ProcessRangeResponse> ProcessRange([FromQuery]ProcessRangeRequest request)
    {
        var range = new NumberRange { Start = (int)(request?.Start), End = (int)request?.End };
        return Ok(_numberService.ProcessRange(range));
    }
}
