using System.Web.Mvc;
using System.Web.Routing;

namespace ChatJoke
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //В целом axd мы не используем в данном приложении... Но оставим...
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //подключаем обработку Роута через атрибуты метадов
            routes.MapMvcAttributeRoutes();

            //дэфолтный роут http:\\host\
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "RegistrationChat", action = "Index"}
            );
        }
    }
}
