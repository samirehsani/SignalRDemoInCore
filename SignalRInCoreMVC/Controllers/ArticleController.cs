using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRInCoreMVC.Hubs;
using SignalRInCoreMVC.Interfaces;
using SignalRInCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SignalRInCoreMVC.Controllers
{
    public class ArticleController : Controller
    {
        public static List<Article> Articles = new List<Article>
        {
            new Article {ArticleId=1, ArticleName= "A1000" },
            new Article {ArticleId=2, ArticleName= "A2000" },
            new Article {ArticleId=3, ArticleName= "A3000" },
        };

        private readonly IHubContext<NotificationHub, INotificationHub> notification;

        public ArticleController(IHubContext<NotificationHub, INotificationHub> notification)
        {
            this.notification = notification;
        }
        public IActionResult Index()
        {
            return View(Articles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Article article)
        {
            var articleData = JsonSerializer.Serialize(article);
            Articles.Add(article);
            await notification.Clients.All.ReceiveMessage(articleData); // send signalR
            return RedirectToAction("Index"); 
        }
    }
}
