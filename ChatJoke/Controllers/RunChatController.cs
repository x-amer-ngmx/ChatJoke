using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ChatJoke.App_Start;

namespace ChatJoke.Controllers
{
    public class RunChatController : Controller
    {
        public RunChatController()
        {
            GlobalConfiguration.Configure(ConfigApi.Register);
        }

        // GET: RunChat
        public ActionResult RoomChat()
        {
            return View();
        }
    }
}