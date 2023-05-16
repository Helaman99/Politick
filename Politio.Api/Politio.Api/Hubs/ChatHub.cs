using Microsoft.AspNetCore.SignalR;
using Politio.Api.Controllers;
using Politio.Api.Data;
using Politio.Api.Services;

namespace Politio.Api.Hubs;

public class ChatHub : Hub
{
    private readonly ChatService _chatService;
    public ChatHub(ChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task<bool> JoinGroupAsync(string chatRoomId)
    {
        Console.WriteLine(chatRoomId);
        int playersJoined = _chatService.AddPlayerToRoom(chatRoomId);
        if (playersJoined == 1 || playersJoined == 2)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
            if (playersJoined == 2) await NotifyToStartGame(chatRoomId);
            return true;
        }
        return false;
    }

    public Task SendMessageToGroup(string chatRoomId, string message)
    {
        return Clients.Group(chatRoomId).SendAsync("ReceiveMessage", message);
    }

    public Task NotifyToStartGame(string chatRoomId)
    {
        return Clients.Group(chatRoomId).SendAsync("StartGame");
    }
}
