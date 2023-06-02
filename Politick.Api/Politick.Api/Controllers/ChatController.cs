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

    [HttpPost("AssignRoomId")]
    public Opponent AssignRoomId([FromBody] Opponent thisPlayer)
        => _chatService.AssignRoomId(thisPlayer);

    [HttpPost("GetOpponent")]
    public Opponent GetOpponent([FromBody] Opponent thisPlayer)
        => _chatService.GetOpponent(thisPlayer);

    [HttpPost("EndGame")]
    public void EndGame(string chatRoomId)
        => _chatService.EndGame(chatRoomId);
}
