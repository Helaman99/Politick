using Microsoft.AspNetCore.Mvc;
using Politick.Api.Services;
using Politick.Api.Data;

namespace Politick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController : ControllerBase
{
    private readonly ILogger<TopicController> _logger;

    public TopicController(ILogger<TopicController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetTopics")]
    public Topic[] GetTopics()
        => TopicService.Topics;
}
