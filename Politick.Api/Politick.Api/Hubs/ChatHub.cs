using Microsoft.AspNetCore.SignalR;
using Politick.Api.Controllers;
using Politick.Api.Data;
using Politick.Api.Services;

namespace Politick.Api.Hubs;

public class ChatHub : Hub
{
    private readonly ChatService _chatService;
    public ChatHub(ChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task<bool> JoinGroupAsync(Opponent player)
    {
        Console.WriteLine(player.ChatRoomId);
        string connectionId = Context.ConnectionId;
        int playersJoined = _chatService.AddPlayerToRoom(connectionId, player.ChatRoomId);
        if (playersJoined == 1 || playersJoined == 2)
        {
            await Groups.AddToGroupAsync(connectionId, player.ChatRoomId);
            if (playersJoined == 2) await NotifyToStartGame(player.ChatRoomId);
            return true;
        }
        return false;
    }

    public Task SendMessageToGroup(string chatRoomId, string message)
    {
        if (_chatService.ValidateConnection(chatRoomId, Context.ConnectionId))
            return Clients.Group(chatRoomId).SendAsync("ReceiveMessage", message);

        throw new HubException($"{nameof(Context.ConnectionId)}: {Context.ConnectionId} " +
                                $"attempted to send a message to a room that they are not a part of!!");
    }

    public Task NotifyToStartGame(string chatRoomId)
    {
        _chatService.StartRoom(chatRoomId);
        return Clients.Group(chatRoomId).SendAsync("StartGame");
    }

    public async Task AddTime(string chatRoomId, string playerTitle)
    {
        if (_chatService.ValidateConnection(chatRoomId, Context.ConnectionId))
            await Clients.Group(chatRoomId).SendAsync("AddTime", playerTitle);
    }

    public async Task LeaveRoom(string chatRoomId)
    {
        if (_chatService.ValidateConnection(chatRoomId, Context.ConnectionId))
            await Clients.Group(chatRoomId).SendAsync("OpponentLeft");
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string connectionId = Context.ConnectionId;
        string chatRoomId = _chatService.DisconnectRoom(connectionId);
        if (chatRoomId != "-1")
            await Clients.Group(chatRoomId).SendAsync("PlayerDisconnected");

        await base.OnDisconnectedAsync(exception);
    }
}
