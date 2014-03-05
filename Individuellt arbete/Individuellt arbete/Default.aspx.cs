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

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Individuellt_arbete.Model.Song> ListView1_GetData()
        {
            return null;
        }

        public IEnumerable<Individuellt_arbete.Model.Album> Unnamed_GetData()
        {
            List<Album> album = new List<Album>();
            album.Add(new Album { AlbumName = "Test", ReleaseDate = "Today", AlbumId = 5 });
            album.Add(new Album{AlbumName = "Yes", AlbumId =3, ReleaseDate ="Yesterday"});
            return album.AsEnumerable();
        }

        public IEnumerable<Individuellt_arbete.Model.Medlem> Unnamed_GetData1()
        {
            List<Medlem> medlem = new List<Medlem>();
            medlem.Add(new Medlem { FirstName = "Test firstname", LastName = "Test lastname" });
            return medlem;
        }

        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Session["username"] = TextBox1.Text;
            Response.Redirect("Default.aspx");
        }
    }
}