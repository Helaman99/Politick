using Microsoft.AspNetCore.Mvc;
using Politick.Api.Data;
using Politick.Api.Services;

namespace Politick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ChatService _chatService;
    private readonly ILogger<ChatController> _logger;

    public ChatController(ChatService chatService, ILogger<ChatController> logger)
    {
        _chatService = chatService;
        _logger = logger;
    }

    //[HttpPost("GetRoomId")]
    //public string GetRoomId(int id, string avatar, string title, int topic, int side)
    //    => _chatService.GetRoomId(id, avatar, title, topic, side);

    [HttpPost("GetRoom")]
    public string GetRoom(string avatar)
        => "This Works!";

    [HttpPost("GetOpponent")]
    public Opponent GetOpponent(string chatRoomId, int id)
        => _chatService.GetOpponent(chatRoomId, id);

    [HttpPost("EndGame")]
    public void EndGame(string chatRoomId)
        => _chatService.EndGame(chatRoomId);
}
