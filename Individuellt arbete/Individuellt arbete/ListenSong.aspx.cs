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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //WIll need to implement a function that uses a ICollection to make the DropDownList work
                //Hopefully this will make it work, but will it be good? Maybe select from Medlem_has_Listened_song instead of just song to avoid listing a huge amount of songs
            }
        }
    }
}