using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected static List<Regex> allowedWithoutLogin = new List<Regex> { new Regex(@"/$",RegexOptions.Singleline|RegexOptions.IgnoreCase), 
                                                                             new Regex(@"/medlem/\d+$"), 
                                                                             new Regex(@"/medlem/register$"),
                                                                             new Regex(@"/albums$"),
                                                                             new Regex(@"/login$")};
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "Global", this.ResolveClientUrl("~/Scripts/Main.js"));
            bool allowed;
            if (Session["currentuser"] != null)
            {
                LoggedInAs.Text = String.Format("Inloggad som: {0} {1}", ((Medlem)Session["currentuser"]).FirstName, ((Medlem)Session["currentuser"]).LastName);
                Linktomemberpage.Visible = true;
                Hyperlinktomemberpage.NavigateUrl = GetRouteUrl("MedlemPage", new { medlemid = ((Medlem)Session["currentuser"]).MedlemId });
                allowed = true;
            }
            else
            {
                LoggedInAs.Text = "Du är inte inloggad än.";
                allowed = allowedWithoutLogin.Any(r => r.IsMatch(Request.Path));
            }

            if (allowed != true)
            {
                Page.SetTempData("errormessage", "Du måste logga in först.");
                Response.RedirectToRoute("login");
                Response.End();
            }
            string errormessage = Page.GetTempData("errormessage") as string;
            if (errormessage != null)
            {
                ErrorPanel.Visible = true;
                ErrorLabel.Text = errormessage;
            }

            string successmessage = Page.GetTempData("successmessage") as string;
            if(successmessage != null)
            {
                SuccessPanel.Visible = true;
                SuccessLabel.Text = successmessage;
            }
        }
    }
}