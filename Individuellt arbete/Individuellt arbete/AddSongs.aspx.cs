using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class AddSongs : System.Web.UI.Page
    {
        Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AlbumList.DataSource = CreateDataSource();
            AlbumList.DataTextField = "AlbumNameTextField";
            AlbumList.DataValueField = "AlbumIdValueField";
            AlbumList.DataBind();
        }
        DataView CreateDataSource()
        {
            List<Album> albums = Service.getAllAlbums();
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("AlbumNameTextField", typeof(String)));
            dt.Columns.Add(new DataColumn("AlbumIdValueField", typeof(int)));

            // Populate the table with sample values.
            albums.ForEach(album => 
                dt.Rows.Add(CreateRow(String.Format("{0} ({1})",album.AlbumName, album.ReleaseDate.Year),album.AlbumId,dt)));
            /*dt.Rows.Add(CreateRow("White", "White", dt));
            dt.Rows.Add(CreateRow("Silver", "Silver", dt));
            dt.Rows.Add(CreateRow("Dark Gray", "DarkGray", dt));
            dt.Rows.Add(CreateRow("Khaki", "Khaki", dt));
            dt.Rows.Add(CreateRow("Dark Khaki", "DarkKhaki", dt));*/

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
    }
}