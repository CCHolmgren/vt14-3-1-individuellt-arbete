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
        protected static List<Regex> allowedWithoutLogin = new List<Regex> { new Regex(@"^/$",RegexOptions.Singleline|RegexOptions.IgnoreCase), 
                                                                             new Regex(@"^/medlem/d+$"), 
                                                                             new Regex(@"^/medlem/register$"),
                                                                             new Regex(@"^/albums$"),
                                                                             new Regex(@"^/login$")};
        protected void Page_Init(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "Global", this.ResolveClientUrl("~/Scripts/Main.js"));

            if (Session["currentuser"] != null)
            {
                LoggedInAs.Text = String.Format("Inloggad som: {0} {1}", ((Medlem)Session["currentuser"]).FirstName, ((Medlem)Session["currentuser"]).LastName);
                Linktomemberpage.Visible = true;
                Hyperlinktomemberpage.NavigateUrl=String.Format("/medlem/{0}", ((Medlem)Session["currentuser"]).MedlemId);
            }
            else
            {
                LoggedInAs.Text = "Du är inte inloggad än.";
            }
            bool allowed = false;
            allowed = allowedWithoutLogin.Any(r => r.IsMatch(Request.Path));
            /*foreach (Regex r in allowedWithoutLogin)
            {
                if (r.IsMatch(Request.Path))
                {
                    allowed = true;
                }
            }*/
            //allowedWithoutLogin.Any();
            //var allowedUrl = allowedWithoutLogin.Any(re => re.IsMatch(Request.Path));
            if (Session["currentuser"] == null && !allowed)
            {
                Page.SetTempData("errormessage", "Du måste logga in först.");
                Response.RedirectToRoute("Login");
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