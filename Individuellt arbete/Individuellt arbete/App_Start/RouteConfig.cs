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

            routes.MapPageRoute("RegisterMedlem", "medlem/register", "~/Pages/MedlemFolder/Register.aspx");
            routes.MapPageRoute("MedlemPage", "medlem/{medlemid}", "~/Pages/MedlemFolder/MedlemPage.aspx");


            routes.MapPageRoute("Albums", "albums", "~/Pages/Album/Album.aspx");
            routes.MapPageRoute("EditAlbums", "albums/edit", "~/Pages/Album/EditAlbum.aspx");

            routes.MapPageRoute("AddGenre", "album-{albumid}/genre/add", "~/Pages/Album/Genre.aspx");

            routes.MapPageRoute("SongsGivenAlbum", "album-{albumid}/songs", "~/Pages/Songs/Songs.aspx");
            routes.MapPageRoute("AddSongs", "album-{albumid}/songs/add", "~/Pages/Songs/AddSongs.aspx");
            routes.MapPageRoute("EditSongsOnAlbum", "album-{albumid}/songs/edit", "~/Pages/Songs/EditSongs.aspx");
            
            routes.MapPageRoute("DeleteSong", "song/{song}/delete", "~/Pages/Song/Delete.aspx");
            //routes.MapPageRoute("ListenToSongs", "songs/listen", "~/Pages/Songs/Listen.aspx");
            
            routes.MapPageRoute("ListenToSong", "song/{song}/listen", "~/Pages/Song/Listen.aspx");

            routes.MapPageRoute("Login", "login", "~/Pages/Login.aspx");
            routes.MapPageRoute("Default", "", "~/Pages/Default.aspx");
            routes.MapPageRoute("Missing", "{*value}", "~/Pages/Missing.aspx");
        }
    }
}

