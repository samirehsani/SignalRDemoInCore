using SignalRInCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRInCoreMVC.Interfaces
{
    public interface INotificationHub
    {
        Task ReceiveMessage(string message);
    }
}
