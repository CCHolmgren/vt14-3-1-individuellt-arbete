using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class ListenSong : System.Web.UI.Page
    {
        Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //WIll need to implement a function that uses a ICollection to make the DropDownList work
                //Hopefully this will make it work, but will it be good? Maybe select from Medlem_has_Listened_song instead of just song to avoid listing a huge amount of songs
                //Code taken from http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.dropdownlist(v=vs.110).aspx
                /*
                 * ColorList.DataSource = CreateDataSource();
                 * ColorList.DataTextField = "ColorTextField";
                 * ColorList.DataValueField = "ColorValueField";
                 * // Bind the data to the control.
                 * ColorList.DataBind();
                 * 
                 * // Set the default selected item, if desired.
                 * ColorList.SelectedIndex = 0;
                 * 
                 * //Need a function in the Service and DataLayer that returns the Betyg table and binds it like this
                 * ICollection CreateDataSource() 
                  {

                     // Create a table to store data for the DropDownList control.
                     DataTable dt = new DataTable();

                     // Define the columns of the table.
                     dt.Columns.Add(new DataColumn("ColorTextField", typeof(String)));
                     dt.Columns.Add(new DataColumn("ColorValueField", typeof(String)));

                     // Populate the table with sample values.
                     dt.Rows.Add(CreateRow("White", "White", dt));
                     dt.Rows.Add(CreateRow("Silver", "Silver", dt));
                     dt.Rows.Add(CreateRow("Dark Gray", "DarkGray", dt));
                     dt.Rows.Add(CreateRow("Khaki", "Khaki", dt));
                     dt.Rows.Add(CreateRow("Dark Khaki", "DarkKhaki", dt));

                     // Create a DataView from the DataTable to act as the data source
                     // for the DropDownList control.
                     DataView dv = new DataView(dt);
                     return dv;

                  }

                  DataRow CreateRow(String Text, String Value, DataTable dt)
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
                 */
            }
        }

        public IEnumerable<Individuellt_arbete.Model.Song> SongRepeater_GetData()
        {
            try
            {
                if (Session["currentuser"] == null)
                    return null;
                int medlemId = (int)Session["currentuser"];
                return Service.getAllListened(medlemId);
            }
            catch (ConnectionException cx)
            {
                ModelState.AddModelError(String.Empty, cx.Message);
                return null;
            }
        }
    }
}