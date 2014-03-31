using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete.Pages.Album
{
    public partial class EditAlbum : System.Web.UI.Page
    {
        Service _service;
        Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        DataPager _datapager;
        DataPager DataPager 
        { 
            get { return _datapager ?? (_datapager = (DataPager)AlbumList.FindControl("DataPager")); } 
        }

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
            if (ModelState.IsValid)
            {
                Model.Album item = new Individuellt_arbete.Model.Album();
                if (TryUpdateModel(item))
                {
                    // Save changes here
                    try
                    {
                        Service.saveAlbum(item);
                        Page.SetTempData("successmessage", "Albumet skapades.");
                        Response.RedirectToRoute("EditAlbums", new {page=DataPager.StartRowIndex / DataPager.PageSize + 1});
                    }
                    catch (ValidationException vx)
                    {
                        var validationResult = vx.Data["validationResult"] as List<ValidationResult>;
                        validationResult.ForEach(r => ModelState.AddModelError(String.Empty, r.ErrorMessage));
                        return;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(String.Empty, ex.Message);
                        return;
                    }
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
                            Page.SetTempData("successmessage", "Albumet uppdaterades.");
                            Response.RedirectToRoute("EditAlbums", new { page = DataPager.StartRowIndex / DataPager.PageSize + 1 });
                            //SuccessMessage = String.Format("Kontakten uppdaterades.");
                            //Response.Redirect(String.Format("?page={0}", DataPager.StartRowIndex / DataPager.PageSize + 1), true);
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            ModelState.AddModelError(String.Empty, ex.Message);
                            //setModelState("Ett oväntat fel inträffade vid uppdateringen av kontakten.");
                        }
                        catch (ValidationException vx)
                        {
                            var validationResult = vx.Data["validationResult"] as List<ValidationResult>;
                            validationResult.ForEach(r => ModelState.AddModelError(String.Empty, r.ErrorMessage));
                        }
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
            AlbumList.EditIndex = -1;
            //if(AlbumList.InsertItemPosition != InsertItemPosition.FirstItem)
                AlbumList.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AlbumList_DeleteItem(int AlbumId)
        {
            try
            {
                Service.deleteAlbum(AlbumId);
                Page.SetTempData("successmessage", "Albumet togs bort.");
                Response.RedirectToRoute("EditAlbums", new { page = DataPager.StartRowIndex / DataPager.PageSize + 1 });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return;
            }
        }

        protected void AddSongsButton_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("AddSongs", new { albumid = Convert.ToInt32(((Button)sender).CommandArgument) });
        }

        protected void AddGenreButton_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("AddGenre", new { albumid = Convert.ToInt32(((Button)sender).CommandArgument) });
        }

        protected void AlbumList_DataBound(object sender, EventArgs e)
        {
            //DataPager.Visible = (DataPager.PageSize < DataPager.TotalRowCount);
        }

        protected void AlbumList_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            AlbumList.InsertItemPosition = InsertItemPosition.None;
        }
    }
}