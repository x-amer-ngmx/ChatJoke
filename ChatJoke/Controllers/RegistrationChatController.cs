using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatJoke.Models;

namespace ChatJoke.Controllers
{
    [AllowAnonymous]
    public class RegistrationChatController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(AuthModel auth)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("regist/", Name = "RegistrationGet")]
        public ActionResult Registration()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("regist/", Name = "RegistrationPost")]
        public ActionResult Registration(RegModel reg)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("confirm/{key}", Name = "")]
        public ActionResult RegistrationConfirm(string key)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("remind/", Name = "ReminderGet")]
        public ActionResult Reminder()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("remind/", Name = "ReminderPost")]
        public ActionResult Reminder(RemModel user)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("info/", Name = "AboutGet")]
        public ActionResult About()
        {
            return View();
        }

    }
}