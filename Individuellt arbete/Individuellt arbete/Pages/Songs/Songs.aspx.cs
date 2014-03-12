using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete.Pages.Songs
{
    public partial class Songs : System.Web.UI.Page
    {
        Service _service;
        Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = String.Format("Låtar på albumet");
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Individuellt_arbete.Model.Song> SongList_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            IEnumerable<Model.Song> songs = Service.getSongList(maximumRows, startRowIndex, out totalRowCount, Convert.ToInt32(Page.RouteData.Values["albumid"]));
            if(songs.Count()==0)
            {
                Page.Title = String.Format("Albumet har inga låtar.");
                ModelState.AddModelError(String.Empty, "Det finns inga låtar associerade med det albumet. Försök igen med ett annat album.");
            }
            return songs;
        }
    }
}