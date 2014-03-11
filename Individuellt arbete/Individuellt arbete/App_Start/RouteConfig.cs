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
            //routes.RouteExistingFiles = true;
            
            routes.MapPageRoute("MedlemPage", "medlem/{medlem}", "~/Pages/MedlemFolder/MedlemPage.aspx");
            routes.MapPageRoute("AddSong", "song/add", "~/Pages/Songs/Add.aspx");
            routes.MapPageRoute("Songs", "songs", "~/Pages/Songs/Songs.aspx");
            routes.MapPageRoute("ListenToSongs", "songs/listen", "~/Pages/Songs/Listen.aspx");
            routes.MapPageRoute("ListenToSong", "song/{song}/listen", "~/Pages/Song/Listen.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/Default.aspx");
            routes.MapPageRoute("Missing", "{*value}", "~/Missing.aspx");
        }
    }
}

