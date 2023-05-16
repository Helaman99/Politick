﻿using Microsoft.AspNetCore.Mvc;
using Politio.Api.Data;
using Politio.Api.Services;

namespace Politio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;
    private readonly ChatService _chatService;

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
}
