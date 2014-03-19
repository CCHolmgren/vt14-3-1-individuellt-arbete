using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete.Pages.Songs
{
    public partial class AddSongs : System.Web.UI.Page
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
        public IEnumerable<Individuellt_arbete.Model.Song> AddSongs_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.getSongList(maximumRows, startRowIndex, out totalRowCount, Convert.ToInt32(RouteData.Values["albumid"]));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                totalRowCount = 0;
                return null;
            }
        }

        protected void InsertNewRow_Click(object sender, EventArgs e)
        {
            AddSongsListView.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        public void AddSongsListView_InsertItem()
        {
            var item = new Individuellt_arbete.Model.Song();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here
                try
                {
                    Service.saveSong(item, Convert.ToInt32(RouteData.Values["albumid"]));
                    Page.SetTempData("successmessage", "Låten skapades.");
                    Response.RedirectToRoute("AddSongs", new { albumid = RouteData.Values["albumid"] });
                }
                catch (ValidationException vx)
                {
                    var validationResult = vx.Data["validationResult"] as List<ValidationResult>;
                    validationResult.ForEach(r => ModelState.AddModelError(String.Empty, r.ErrorMessage));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                    return;
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AddSongsListView_UpdateItem(int SongId)
        {
            Individuellt_arbete.Model.Song item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            try
            {
                item = Service.getSong(SongId);
            }
            catch (SqlException sx)
            {
                ModelState.AddModelError(String.Empty, sx.Message);
                return;
            }
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", SongId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                try
                {
                    Service.saveSong(item, Convert.ToInt32(RouteData.Values["albumid"]));
                    Response.RedirectToRoute("AddSongs", new { albumid = RouteData.Values["albumid"] });
                }
                catch (ValidationException vx)
                {
                    var validationResult = vx.Data["validationResult"] as List<ValidationResult>;
                    validationResult.ForEach(r => ModelState.AddModelError(String.Empty, r.ErrorMessage));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                    return;
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AddSongsListView_DeleteItem(int SongId)
        {
            try
            {
                Service.removeSong(SongId);
                Response.RedirectToRoute("AddSongs", new { albumid = RouteData.Values["albumid"] });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return;
            }
        }
    }
}