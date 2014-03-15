using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class AddSongs : System.Web.UI.Page
    {
        Service _service;
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        List<Song> SongList
        {
            get { return Session["AddedSongs"] as List<Song>; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                /*AlbumList.DataSource = CreateDataSource();
                AlbumList.DataTextField = "AlbumNameTextField";
                AlbumList.DataValueField = "AlbumIdValueField";
                AlbumList.DataBind();*/
            }

            if (Session["AddedSongs"] == null)
            {
                Session["AddedSongs"] = new List<Song>();
            }
        }
        DataView CreateDataSource()
        {
            List<Album> albums;
            try
            {
                albums = Service.getAllAlbums();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return new DataView();
            }
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("AlbumNameTextField", typeof(String)));
            dt.Columns.Add(new DataColumn("AlbumIdValueField", typeof(int)));

            // Populate the table with sample values.
            albums.ForEach(album => 
                dt.Rows.Add(CreateRow(
                String.Format("{0} ({1})",album.AlbumName, album.ReleaseYear)
                                        ,album.AlbumId,dt)));

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            DataView dv = new DataView(dt);
            return dv;

        }
        DataRow CreateRow(String Text, int Value, DataTable dt)
        {

            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = dt.NewRow();

            // This DataRow contains the ColorTextField and ColorValueField 
            // fields, as defined in the CreateDataSource method. Set the 
            // fields with the appropriate value. Remember that column 0 
            // is defined as ColorTextField, and column 1 is defined as 
            // ColorValueField.
            dr[0] = Text;
            dr[1] = Value;

            return dr;
        }

        protected void SaveSongButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                /*ModelState.AddModelError(String.Empty, AlbumList.SelectedItem.ToString());
                ModelState.AddModelError("", AlbumList.SelectedValue);
                ModelState.AddModelError("", AlbumList.SelectedIndex.ToString());
                Song newSong = new Song { Length = int.Parse(Length.Text), SongName = SongName.Text, BandName = BandName.Text };
                SongList.Add(newSong/*, AlbumList.SelectedValue);*/
            }
        }

        public IEnumerable<Individuellt_arbete.Model.Song> AddedSongsRepeater_GetData()
        {
            return SongList;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Individuellt_arbete.Model.Song> AddSongsListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.getSongList(maximumRows, startRowIndex, out totalRowCount, Convert.ToInt32(RouteData.Values["albumid"]));
            }
            catch (Exception ex)
            {
                totalRowCount = 0;
                ModelState.AddModelError(String.Empty, ex.Message);
                return null;
            }
        }

        public void AddSongsListView_InsertItem()
        {
            Model.Song item = new Individuellt_arbete.Model.Song();
            if (TryUpdateModel(item))
            {
                // Save changes heretry
                try
                {
                    Service.saveSong(item, Convert.ToInt32(RouteData.Values["albumid"]));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                    return;
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AddSongsListView_DeleteItem(int SongId)
        {
            try
            {
                Service.removeSong(SongId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AddSongsListView_UpdateItem(int SongId)
        {
            Individuellt_arbete.Model.Song item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError(String.Empty, String.Format("Item with id {0} was not found", SongId));
                return;
            }

            if (TryUpdateModel(item))
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                try
                {
                    Service.saveSong(item, 0);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, "Låten kunde inte sparas.");
                    return;
                }
            }
        }

        protected void AddSongButton_Click(object sender, EventArgs e)
        {
            AddSongsListView.InsertItemPosition = InsertItemPosition.LastItem;
        }
    }
}