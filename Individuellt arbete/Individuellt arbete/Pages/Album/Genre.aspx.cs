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
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void AddGenreButton_Click(object sender, EventArgs e)
        {
            AddGenreListView.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Individuellt_arbete.Model.AlbumHasGenre> AddGenreListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            List<Model.AlbumHasGenre> ahg = Service.getGenresFromAlbum(Convert.ToInt32(RouteData.Values["albumid"]));
            totalRowCount = ahg.Count;
            return ahg;
        }

        public void AddGenreListView_InsertItem()
        {
            var item = new Individuellt_arbete.Model.Genre();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AddGenreListView_DeleteItem(int GenreId)
        {

        }

        protected void AddGenreListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
                DropDownList GenreDDL = (DropDownList)AddGenreListView.InsertItem.FindControl("GenreDDL");
                GenreDDL.DataSource = CreateDataSource();
                GenreDDL.DataTextField = "MemberNameTextField";
                GenreDDL.DataValueField = "MemberIdValueField";
                GenreDDL.DataBind();
        }
    }
}