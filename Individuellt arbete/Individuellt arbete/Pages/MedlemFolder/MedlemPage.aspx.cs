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
        int CurrentUserId
        {
            get { return ((Model.Medlem)Session["currentuser"]).MedlemId; }
        }
        int MedlemId
        {
            get { return Convert.ToInt32(RouteData.Values["medlemid"]); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //TODO: Change back this line to 
            //int medlemId = Convert.ToInt32(Page.RouteData.Values["medlem"]);
            //It's only for debuggign.
            try
            {
                Model.Medlem medlem = Service.getMedlem(MedlemId);
                if (medlem != null)
                {
                    if (CurrentUserId == MedlemId)
                    {
                        HelloMessage.Visible = true;
                        RecentlyListenedListView.EmptyDataTemplate = RecentlyListenedListView.InsertItemTemplate;
                    }
                    else
                    {
                        RecentlyListenedListView.EmptyDataTemplate = RecentlyListenedListView.EditItemTemplate;
                    }

                    FirstName.Text = medlem.FirstName;
                    LastName.Text = medlem.LastName;
                    PrimaryEmail.Text = medlem.PrimaryEmail;
                    Page.Title = String.Format("Medlem - {0} {1}", medlem.FirstName, medlem.LastName);
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Medlemmen du söker kan inte finnas.");
                    Page.Title = String.Format("Medlemmen kunde inte hittas.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Individuellt_arbete.Model.RecentlyListened> RecentlyListenedListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                IEnumerable<Model.RecentlyListened> rl = Service.getSongListLatest(MedlemId);
                totalRowCount = rl.Count();
                return rl;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                totalRowCount = 0;
                return null;
            }
        }

        protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            try
            {
                Service.gradeSong(Convert.ToInt32(ddl.Attributes["db-SongId"]), MedlemId, Convert.ToInt32(ddl.SelectedValue));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return;
            }
            Response.RedirectToRoute("MedlemPage", new { medlemid = MedlemId });
        }
    }
}