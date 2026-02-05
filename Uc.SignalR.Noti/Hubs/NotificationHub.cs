using Microsoft.AspNetCore.SignalR;

namespace Uc.SignalR.Noti.Hubs;

public class NotificationHub : Hub
{
    public async Task SendNotification(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", user, message);
    }

    public async Task SendNotificationToUser(string userId, string message)
    {
        await Clients.User(userId).SendAsync("ReceiveNotification", message);
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await Clients.Group(groupName).SendAsync("ReceiveNotification", $"{Context.ConnectionId} has joined the group {groupName}.");
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        await Clients.Group(groupName).SendAsync("ReceiveNotification", $"{Context.ConnectionId} has left the group {groupName}.");
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveNotification", $"{Context.ConnectionId} connected");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.SendAsync("ReceiveNotification", $"{Context.ConnectionId} disconnected");
        await base.OnDisconnectedAsync(exception);
    }
}
