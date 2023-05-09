using Microsoft.AspNetCore.Mvc;
using Politio.Api.Services;
using Politio.Api.Data;

namespace Politio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicController
{
    [HttpGet("GetTopics")]
    public Topic[] GetTopics()
        => TopicService.Topics;
}
