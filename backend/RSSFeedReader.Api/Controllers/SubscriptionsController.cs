using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionService _service;

    public SubscriptionsController(SubscriptionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetSubscriptions()
    {
        var subscriptions = _service.GetSubscriptions();
        return Ok(subscriptions);
    }

    [HttpPost]
    public IActionResult AddSubscription([FromBody] AddSubscriptionRequest request)
    {
        var result = _service.AddSubscription(request?.Url);
        if (!result.IsSuccess)
        {
            return BadRequest(new { error = result.ErrorMessage });
        }

        return Created(string.Empty, result.Value);
    }
}
