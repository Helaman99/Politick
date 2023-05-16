using Microsoft.AspNetCore.Mvc;
using Politio.Api.Services;
using Politio.Api.Data;

namespace Politio.Api.Controllers;

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
