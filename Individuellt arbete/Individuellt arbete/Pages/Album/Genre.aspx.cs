using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Individuellt_arbete.Pages.Album
{
    public partial class Genre : System.Web.UI.Page
    {
        Service _service;
        Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Model.Album album = Service.getAlbumById(Convert.ToInt32(RouteData.Values["albumid"]));
                if(album == null)
                {
                    ModelState.AddModelError(String.Empty, "Albumet kunde inte hittas, försök igen med ett annat album.");
                    NewGenreDDL.Visible = false;
                    return;
                }
                else
                {
                    AlbumName.Text = String.Format("Album: {0}",album.AlbumName);
                    Page.Title = String.Format("{0}: {1}", album.AlbumName, Page.Title);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Ett fel uppstod när albumet hämtades.");
                return;
            }
            try
            {
                NewGenreDDL.DataSource = Service.getAllGenres();
                NewGenreDDL.DataTextField = "GenreName";
                NewGenreDDL.DataValueField = "GenreId";
                NewGenreDDL.DataBind();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Ett fel uppstod när genrerna hämtades.");
                return;
            }
        }
        [Obsolete()]
        DataView CreateDataSource()
        {
            List<Model.Genre> genres;
            try
            {
                //genres = Service.getGenresFromAlbum(Convert.ToInt32(RouteData.Values["albumid"]));
                genres = Service.getAllGenres();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return new DataView();
            }
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("MemberNameTextField", typeof(String)));
            dt.Columns.Add(new DataColumn("MemberIdValueField", typeof(int)));

            // Populate the table with sample values.e
            genres.ForEach(genre =>
                dt.Rows.Add(CreateRow(String.Format("{0}"
                                        , genre.GenreName)
                                        , genre.GenreId, dt)));

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            DataView dv = new DataView(dt);
            return dv;
        }
        [Obsolete()]
        DataRow CreateRow(String Text, int Value, DataTable dt)
        {

            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = dt.NewRow();

            // This DataRow contains the ColorTextField and ColorValueField 
            // fields, as defined in the CreateDataSource method. Set the 
            // fields with the appropriate value. Remember that column 0 
            // is defined as ColorTextField, and column 1 is defined as 
            // ColorValueField.
            dr[0] = Text;
            dr[1] = Value;

            return dr;
        }

        public IEnumerable<Individuellt_arbete.Model.AlbumHasGenre> AlbumGenreRpr_GetData()
        {
            try
            {
                return Service.getGenresFromAlbum(Convert.ToInt32(RouteData.Values["albumid"]));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return null;
            }
        }

        protected void AddGenreButton_Click(object sender, EventArgs e)
        {
            int genreId = Convert.ToInt32(NewGenreDDL.SelectedValue);
            int albumId = Convert.ToInt32(RouteData.Values["albumid"]);
            try
            {
                Service.addGenreToAlbum(genreId, albumId);
                Response.RedirectToRoute("AddGenre", new { albumid = albumId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return;
            }
        }
    }
}