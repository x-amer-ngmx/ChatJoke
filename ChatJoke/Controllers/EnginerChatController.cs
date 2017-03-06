using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatJoke.Controllers
{
    public class EnginerChatController : Controller
    {
        // GET: EnginerChat
        public ActionResult ChatRoom()
        {
            return View();
        }
    }
}