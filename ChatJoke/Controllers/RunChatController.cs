using System.Web.Mvc;
using ChatJoke.App_Start;
using ChatJoke.Module.Filter;

namespace ChatJoke.Controllers
{
    [AuthorizUser]
    public class RunChatController : Controller
    {
        public RunChatController()
        {
            System.Web.Http.GlobalConfiguration.Configure(ConfigApi.Register);
        }

        // GET: RunChat
        [Route("chat/", Name = "RegistrationGet")]
        public ActionResult RoomChat()
        {
            return View();
        }
    }
}