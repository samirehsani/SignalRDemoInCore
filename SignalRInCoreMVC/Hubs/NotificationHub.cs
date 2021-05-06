using Microsoft.AspNetCore.SignalR;
using SignalRInCoreMVC.Interfaces;
using SignalRInCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRInCoreMVC.Hubs
{
    public class NotificationHub :Hub<INotificationHub>
    {
        public Task SendMessageToAll(string message)
        {
            return Clients.All.ReceiveMessage(message);
        }

        public Task SubscribeToCategory(string category)
        {
             return Groups.AddToGroupAsync(Context.ConnectionId, category);
        }

        public Task SendMessageToCategory(string category, string message)
        {
            return Clients.Group(category).ReceiveMessage(message);
        }

        public Task UnSubscribeFromCategory(string category)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, category);
        }
    }
}
