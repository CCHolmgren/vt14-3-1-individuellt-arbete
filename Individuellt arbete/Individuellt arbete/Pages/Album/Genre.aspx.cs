using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (!IsPostBack)
            {
                NewGenreDDL.DataSource = CreateDataSource();
                NewGenreDDL.DataTextField = "MemberNameTextField";
                NewGenreDDL.DataValueField = "MemberIdValueField";
                NewGenreDDL.DataBind();
            }
        }
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
            return Service.getGenresFromAlbum(Convert.ToInt32(RouteData.Values["albumid"]));
        }

        protected void AddGenreButton_Click(object sender, EventArgs e)
        {
            int genreId = Convert.ToInt32(NewGenreDDL.SelectedValue);
            int albumId = Convert.ToInt32(RouteData.Values["albumid"]);
            Service.addGenreToAlbum(genreId, albumId);
            Response.RedirectToRoute("AddGenre", new { albumid = albumId });
        }

        protected void AlbumGenreRpr_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (AlbumGenreRpr.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label missingData = (Label)e.Item.FindControl("MissingData");
                    missingData.Visible = true;
                }
            }
        }
    }
}