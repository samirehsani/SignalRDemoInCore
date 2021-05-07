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
        /// <summary>
        /// Send message to all client
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToAll(string message)
        {
            return Clients.All.AllReceiveMessage(message);
        }

        /// <summary>
        /// Subscribe client to category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Task SubscribeToCategory(string category)
        {
             return Groups.AddToGroupAsync(Context.ConnectionId, category);
        }

        /// <summary>
        /// send message to category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendMessageToCategory(string category, string message)
        {
            return Clients.Group(category).CategoryReceiveMessage(message);
        }

        /// <summary>
        /// Unsubscribe client from category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Task UnSubscribeFromCategory(string category)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, category);
        }
    }
}
