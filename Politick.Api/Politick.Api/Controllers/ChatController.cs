using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Politick.Api.Data;
using Politick.Api.Services;

namespace Politick.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;
    private readonly ILogger<ChatController> _logger;

    public ChatController(ChatService chatService, ILogger<ChatController> logger)
    {
        _chatService = chatService;
        _logger = logger;
    }

    [HttpPost("GetRoomId")]
    public string GetRoomId([FromBody] GetRoomIdModel model)
        => _chatService.GetRoomId(model.Id, model.Topic, model.Side);

    public class GetRoomIdModel
    {
        public int Id { get; set; }
        public int Topic { get; set; }
        public int Side { get; set; }
    }

    [HttpPost("DeleteRoom")]
    public bool DeleteRoom(int playerId)
        => _chatService.DeleteRoom(playerId);

    [HttpPost("EndGame")]
    public void EndGame(string chatRoomId)
        => _chatService.EndGame(chatRoomId);
}
