using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Web.Script.Serialization;

namespace IP_FinalProject
{
    public partial class Rental : System.Web.UI.Page
    {
        public String currentRoom;
        public String[] image;
        public JavaScriptSerializer javaSerial = new JavaScriptSerializer();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["validUser"]))
            {
                this.Page.MasterPageFile = "~/MasterPages/Admin.Master";
            }
            else this.Page.MasterPageFile = "~/MasterPages/Booking.Master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateRooms();
                SqlConnection room = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condo;Integrated Security=True");
                SqlCommand cmd;
                room.Open();
                cmd = new SqlCommand("SELECT description FROM Rooms ", room);

                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    lblDescription.Text = read[0].ToString();
                }
                roomsDLL.SelectedIndex = 0;
                currentRoom = roomsDLL.SelectedValue+"/";

                Session["roomIndex"] = roomsDLL.SelectedIndex.ToString();
                Session["roomValue"] = roomsDLL.SelectedValue.ToString();

                populateRoomImages(roomsDLL.SelectedValue);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "loopRoomImages();", true);
            }

            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection rooms = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condo;Integrated Security=True");
            SqlCommand cmd;
            rooms.Open();
            cmd = new SqlCommand("SELECT description FROM Rooms WHERE roomID = @roomNumber", rooms);
            cmd.Parameters.AddWithValue("@roomNumber", roomsDLL.SelectedValue);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblDescription.Text = reader[0].ToString();
            }

            Session["roomIndex"] = roomsDLL.SelectedIndex.ToString();
            Session["roomValue"] = roomsDLL.SelectedValue.ToString();

            currentRoom = roomsDLL.SelectedValue+"/";
            populateRoomImages(roomsDLL.SelectedValue);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script","loopRoomImages();",true);
        }
        private void populateRooms()
        {
            SqlConnection rooms = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condo;Integrated Security=True");
            SqlCommand cmd;
            rooms.Open();
            cmd = new SqlCommand("SELECT roomID FROM Rooms ", rooms);

            SqlDataReader read = cmd.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                roomsDLL.Items.Insert(count, new ListItem(read[0].ToString()));
                count++;
            }
            roomsDLL.SelectedIndex = 0;
        }
        private void populateRoomImages(String roomNum)
        {
            String path = Server.MapPath("/");
            path += "Images\\"+roomNum+"\\";

            String[] ImagePaths = Directory.GetFiles(path);
            List<String> temp = new List<String>();

            foreach (String item in ImagePaths)
            {
                int chop = item.IndexOf("Images\\"+roomNum+"\\", 0);
                temp.Add(item.Substring((chop + 12), item.Length - (chop + 12)));

            }
            image = temp.ToArray();
        }
        public String[] getRoomImages()
        {
            return image;
        }
        public String getRoom()
        {
            return currentRoom;
        }
    }
}