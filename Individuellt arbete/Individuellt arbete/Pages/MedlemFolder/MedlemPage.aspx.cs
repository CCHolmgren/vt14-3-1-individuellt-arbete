using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete.Pages.MedlemFolder
{
    public partial class MedlemPage : System.Web.UI.Page
    {
        Service _service;
        Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            int medlemId = Convert.ToInt32(Page.RouteData.Values["medlem"]);
            
            Medlem medlem = Service.getMedlem(medlemId);
            if (medlem != null)
            {
                FirstName.Text = medlem.FirstName;
                LastName.Text = medlem.LastName;
                PrimaryEmail.Text = medlem.PrimaryEmail;
            }
            else
                ModelState.AddModelError(String.Empty, "Medlemmen du söker kan inte finnas.");
        }
    }
}