using Individuellt_arbete.Model;
using Individuellt_arbete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class Register : System.Web.UI.Page
    {
        Service _service;
        Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Medlem medlem = new Medlem { FirstName = FirstName.Text, LastName = LastName.Text, PrimaryEmail = PrimaryEmail.Text };
                    Service.createMedlem(medlem);
                    Page.SetTempData("SuccessMessage", "Kontakten skapades.");
                    Response.RedirectToRoute("MedlemPage", new { medlem = medlem.MedlemId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, String.Format("Ett fel uppstod vid skapandet av medlemen. {0}", ex.Message));
                }
            }
        }
    }
}