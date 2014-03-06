using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            Label.Text = Session["username"] as string;
        }

        public IEnumerable<Individuellt_arbete.Model.Album> Unnamed_GetData()
        {
            List<Album> album = new List<Album>();
            album.Add(new Album { AlbumName = "Test", ReleaseDate = "Today", AlbumId = 5 });
            album.Add(new Album{ AlbumName = "Yes", AlbumId = 3, ReleaseDate ="Yesterday" });
            return album.AsEnumerable();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Session["username"] = TextBox1.Text;
            Response.Redirect("Default.aspx");
        }

        protected void MedlemId_TextChanged(object sender, EventArgs e)
        {
            Session["currentuser"] = new Medlem { MedlemId = 1 };
            Response.Redirect("ListenSong.aspx");
        }

        protected void MedlemIdSet_Click(object sender, EventArgs e)
        {
            Session["currentuser"] = new Medlem { MedlemId = int.Parse(MedlemId.Text) };
            Response.Redirect("ListenSong.aspx");
        }
    }
}