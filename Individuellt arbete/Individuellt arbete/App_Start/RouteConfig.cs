using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Individuellt_arbete
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ListenToSong", "song/listen", "~/Pages/Songs/Listen.aspx");
            routes.MapPageRoute("ListenToSongMedlem", "song/{medlem}/listen", "~/Pages/Songs/Listen.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/Default.aspx");
        }
    }
}

