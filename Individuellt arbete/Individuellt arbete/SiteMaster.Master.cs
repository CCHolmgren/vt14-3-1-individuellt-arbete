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
        protected static List<Regex> allowedWithoutLogin = new List<Regex> { new Regex(@"^/$",RegexOptions.Singleline|RegexOptions.IgnoreCase), new Regex(@"^/medlem/d+$") };
        protected void Page_Init(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContextHandler.Text = Request.Path;

            bool allowed = false;
            foreach (Regex r in allowedWithoutLogin)
            {
                if (r.IsMatch(Request.Path))
                {
                    allowed = true;
                }
            }
            //allowedWithoutLogin.Any();
            //var allowedUrl = allowedWithoutLogin.Any(re => re.IsMatch(Request.Path));
            if (Session["currentuser"] == null && !allowed)
            {
                Session["errormessage"] = "Du måste logga in först.";
                Response.RedirectToRoute("Login");
            }
        }
    }
}