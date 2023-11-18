using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Politick.Api.Data;
using Politick.Api.Services;
using System.Security.Claims;

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

    private string GetEmailFromClaims() // Maybe update this to be inherited?
    {
        return User.Claims.First(e => e.Type == ClaimTypes.Email).Value;
    }

    [HttpPost("AssignRoomId")]
    public Opponent AssignRoomId([FromBody] Opponent thisPlayer)
        => _chatService.AssignRoomId(new Opponent(GetEmailFromClaims(), // Opponent object comes in with an empty email to protect PII
                                                    thisPlayer.Avatar, 
                                                    thisPlayer.Title, 
                                                    thisPlayer.Topic, 
                                                    thisPlayer.Side, 
                                                    thisPlayer.ChatRoomId));

    [HttpPost("GetOpponent")]
    public Opponent GetOpponent([FromBody] Opponent thisPlayer)
        => _chatService.GetOpponent(new Opponent(GetEmailFromClaims(),
                                                    thisPlayer.Avatar,
                                                    thisPlayer.Title,
                                                    thisPlayer.Topic,
                                                    thisPlayer.Side,
                                                    thisPlayer.ChatRoomId));

    [HttpPost("EndGame")]
    public void EndGame(string chatRoomId)
        => _chatService.EndGame(chatRoomId);

    [HttpGet("DebatesInProgress")]
    public int GetDebatesInProgress()
        => _chatService.GetRoomsInProgress();
}
