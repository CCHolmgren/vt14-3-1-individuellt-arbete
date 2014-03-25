using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class Login : System.Web.UI.Page
    {
        Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataView dv = CreateDataSource();
            if (dv.Count == 0)
            {
                ModelState.AddModelError(String.Empty, "Det finns inga medlemmar än. Registrera en medlem från menyn och försök igen.");
                return;
            }
            MemberList.DataSource = dv;
            MemberList.DataTextField = "MemberNameTextField";
            MemberList.DataValueField = "MemberIdValueField";
            MemberList.DataBind();
        }
        DataView CreateDataSource()
        {
            List<Model.Medlem> medlems;
            try
            {
                medlems = Service.getAllMedlems();
                Session["medlems"] = medlems;
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
            medlems.ForEach(medlem =>
                dt.Rows.Add(CreateRow(String.Format("{0} {1}"
                                        , medlem.FirstName
                                        , medlem.LastName)
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

        protected void MedlemIdSet_Click(object sender, EventArgs e)
        {
            int medlemIndex = Convert.ToInt32(MemberList.SelectedValue);
            Session["currentuser"] = (Session["medlems"] as List<Model.Medlem>)[medlemIndex-1];
            //Session["currentuser"] = int.Parse(MemberList.SelectedValue);
            Response.RedirectToRoute("MedlemPage", new { medlemid = MemberList.SelectedValue });
        }
    }
}