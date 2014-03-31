using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Linq;
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
                NewGenreDDL.DataSource = CreateDataSource();
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
        DataView CreateDataSource()
        {
            List<Model.Genre> allGenres;
            List<Model.AlbumHasGenre> previouslyAddedGenres;
            List<Model.Genre> fromAHGToGenre = new List<Model.Genre>();
            try
            {
                previouslyAddedGenres = Service.getGenresFromAlbum(Convert.ToInt32(RouteData.Values["albumid"]));
                previouslyAddedGenres.ForEach(g => 
                    fromAHGToGenre.Add(
                        new Model.Genre
                            {
                                GenreId = g.GenreId, 
                                GenreName = g.Genre
                            }));

                allGenres = Service.getAllGenres();
                
                List<int> notAddedGenreIds = allGenres.Select(c => c.GenreId)
                                              .Except(fromAHGToGenre.Select(c => c.GenreId))
                                              .ToList();

                allGenres = allGenres.Where(c => notAddedGenreIds.Contains(c.GenreId))
                                     .ToList();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "Hämtandet av genrer mislyckades. Försök igen.");
                return new DataView();
            }
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("GenreName", typeof(String)));
            dt.Columns.Add(new DataColumn("GenreId", typeof(int)));

            // Populate the table with sample values.e
            allGenres.ForEach(genre =>
                dt.Rows.Add(CreateRow(String.Format("{0}"
                                        , genre.GenreName)
                                        , genre.GenreId, dt)));

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            DataView dv = new DataView(dt);
            return dv;
        }
        DataRow CreateRow(String Text, int Value, DataTable dt)
        {
            DataRow dr = dt.NewRow();
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