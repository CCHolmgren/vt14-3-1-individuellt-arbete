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

        public void AlbumList_InsertItem()
        {
            Model.Album item = new Individuellt_arbete.Model.Album();
            if(TryUpdateModel(item))
            {
                // Save changes here
                try
                {
                    Service.saveAlbum(item);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                    return;
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AlbumList_UpdateItem(int AlbumId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Model.Album album = Service.getAlbumById(AlbumId);

                    if (album == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError(String.Empty, String.Format("Item with id {0} was not found", AlbumId));
                        return;
                    }

                    if (TryUpdateModel(album))
                    {
                        // Save changes here, e.g. MyDataLayer.SaveChanges();
                        try
                        {
                            Service.saveAlbum(album);
                            //SuccessMessage = String.Format("Kontakten uppdaterades.");
                            //Response.Redirect(String.Format("?page={0}", DataPager.StartRowIndex / DataPager.PageSize + 1), true);
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            ModelState.AddModelError(String.Empty, ex.Message);
                            //setModelState("Ett oväntat fel inträffade vid uppdateringen av kontakten.");
                        }
                        /*catch (ValidationException vx)
                        {
                            //var validationResult = vx.Data["validationResult"] as List<ValidationResult>;
                            //validationResult.ForEach(r => ModelState.AddModelError(String.Empty, r.ErrorMessage));
                        }*/
                    }
                }
                catch (ArgumentException ax)
                {
                    ModelState.AddModelError(String.Empty, ax.Message);
                    //setModelState(ax.Message);
                }
                catch (ConnectionException cx)
                {
                    ModelState.AddModelError(String.Empty, cx.Message);
                    //setModelState(cx.Message);
                }
            }
        }

        protected void NewAlbum_Click(object sender, EventArgs e)
        {
            AlbumList.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AlbumList_DeleteItem(int AlbumId)
        {
            try
            {
                Service.deleteAlbum(AlbumId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return;
            }
        }
    }
}