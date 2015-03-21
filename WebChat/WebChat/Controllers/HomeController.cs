using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class HomeController : Controller
    {
        static ChatModel chatModel;

        public ActionResult Index(string user, bool? logOn, string message)
        {
            if (chatModel == null) chatModel = new ChatModel();

            if (chatModel.Messages.Count > 10)
                chatModel.Messages.RemoveAt(0);

            if (!Request.IsAjaxRequest())
            {
                return View(chatModel);
            }
            else if (logOn != null && (bool)logOn)
            {
                chatModel.Users.Add(new User(user));

                return PartialView("Chat", chatModel);
            }
            else
            {
                User currentUser = chatModel.Users.FirstOrDefault(u => u.Name == user);

                if (!string.IsNullOrEmpty(message))
                {
                    chatModel.Messages.Add(new Message()
                    {
                        User = currentUser,
                        Text = message
                    });
                }

                return PartialView("History", chatModel);
            }
        }
    }
}
