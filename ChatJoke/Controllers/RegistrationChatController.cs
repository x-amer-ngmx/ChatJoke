using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatJoke.Controllers
{
    public class RegistrationChatController : Controller
    {
        // GET: RegestrationChat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult RegistrationConfirm()
        {
            return View();
        }

        public ActionResult Reminder()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}