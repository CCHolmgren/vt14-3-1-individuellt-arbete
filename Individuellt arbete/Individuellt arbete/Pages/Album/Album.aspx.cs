using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete.Pages.Album
{
    public partial class Album : System.Web.UI.Page
    {
        Service _service;
        Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Individuellt_arbete.Model.Album> AlbumList_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.getAlbumList(maximumRows, startRowIndex, out totalRowCount);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                totalRowCount = 0;
                return null;
            }
        }

        protected void NewAlbum_Click(object sender, EventArgs e)
        {
            AlbumList.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        protected void AddAlbumButton_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("EditAlbums");
        }
    }
}