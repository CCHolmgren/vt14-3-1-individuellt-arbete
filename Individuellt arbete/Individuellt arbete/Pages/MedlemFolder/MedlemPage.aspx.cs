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
            int sessionCurrentUser = Convert.ToInt32(Session["currentuser"]);
            int medlemIdRoute = Convert.ToInt32(RouteData.Values["medlemid"]);
            //TODO: Change back this line to 
            //int medlemId = Convert.ToInt32(Page.RouteData.Values["medlem"]);
            //It's only for debuggign.
            try
            {
                Model.Medlem medlem = Service.getMedlem(medlemIdRoute);
                if (medlem != null)
                {
                    if (sessionCurrentUser == medlemIdRoute)
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

        public IEnumerable<Individuellt_arbete.Model.RecentlyListened> LastListened_GetData()
        {
            //TODO: Change back this to return Service.getSongListLatest((int)(RouteData.Values["medlem"]));
            //It's only for debugging
            return Service.getSongListLatest(Convert.ToInt32(RouteData.Values["medlem"]));
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Individuellt_arbete.Model.RecentlyListened> RecentlyListenedListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            IEnumerable<Model.RecentlyListened> rl = Service.getSongListLatest(Convert.ToInt32(RouteData.Values["medlem"]));
            totalRowCount = rl.Count();
            return rl;
        }
    }
}