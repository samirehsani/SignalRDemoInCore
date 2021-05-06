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
        public async Task SendMessage(Article article)
        {
            await Clients.All.SendMessageAsync(article);
        }
    }
}
