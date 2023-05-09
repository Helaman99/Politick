using Microsoft.AspNetCore.SignalR;
namespace Politio.Api.Hubs;

public class ChatHub : Hub
{
    public Task JoinGroup(string groupName)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public Task SendMessageToGroup(string groupName, string message)
    {
        return Clients.Group(groupName).SendAsync("ReceiveMessage", message);
    }
}
