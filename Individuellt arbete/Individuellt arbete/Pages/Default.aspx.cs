using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class Default : System.Web.UI.Page
    {
        Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MemberList.DataSource = CreateDataSource();
                MemberList.DataTextField = "MemberNameTextField";
                MemberList.DataValueField = "MemberIdValueField";
                MemberList.DataBind();
            }
        }
        DataView CreateDataSource()
        {
            List<Medlem> medlems = Service.getAllMedlems();
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("MemberNameTextField", typeof(String)));
            dt.Columns.Add(new DataColumn("MemberIdValueField", typeof(int)));

            // Populate the table with sample values.e
            medlems.ForEach(medlem =>
                dt.Rows.Add(CreateRow(String.Format("{0} {1}", medlem.FirstName, medlem.LastName)
                                        , medlem.MedlemId, dt)));

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
        public IEnumerable<Individuellt_arbete.Model.Album> Unnamed_GetData()
        {
            List<Album> album = new List<Album>();
            album.Add(new Album { AlbumName = "Test", ReleaseDate = System.DateTime.Today, AlbumId = 5 });
            album.Add(new Album{ AlbumName = "Yes", AlbumId = 3, ReleaseDate =DateTime.Today });
            return album.AsEnumerable();
        }

        protected void MedlemIdSet_Click(object sender, EventArgs e)
        {
            Session["currentuser"] = int.Parse(MemberList.SelectedValue);
            Response.RedirectToRoute("MedlemPage", new { medlem = MemberList.SelectedValue });
        }
    }
}