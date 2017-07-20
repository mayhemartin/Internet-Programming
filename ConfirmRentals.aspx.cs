using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace IP_FinalProject
{
    public partial class ConfirmRentals : System.Web.UI.Page
    {
        int currentPending;
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["CondoRoomsConnectionString"].ConnectionString;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                if (!Convert.ToBoolean(Session["validUser"]))
                {
                    throw new HttpException(403, "");

                }
            }
            catch
            {
                Response.Redirect("~/Error/403.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateRooms();
                Session["pending"] = -1;

                lblReservation.Visible = false;
                lblCustomer.Visible = false;
                DetailsView1.Visible = false;
                DetailsView2.Visible = false;
                confirmPending.Visible = false;
                deletePending.Visible = false;
                cancel.Visible = false;
            }            
        }
        private void populateRooms()
        {
            SqlConnection rooms = new SqlConnection(connString);
            SqlCommand cmd;
            rooms.Open();
            cmd = new SqlCommand("SELECT roomID FROM Rooms ", rooms);

            SqlDataReader read = cmd.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                dllRooms.Items.Insert(count, new ListItem(read[0].ToString()));
                count++;
            }
            dllRooms.SelectedIndex = 0;
            currentPending = Convert.ToInt32(dllRooms.SelectedValue);
        }
        protected void bookingCalendar_DayRender(Object sender, DayRenderEventArgs e)
        {

            renderPending(sender, e);
            renderReserved(sender, e);
            renderAvailable(sender, e);
            
        }
        private void renderAvailable(Object sender, DayRenderEventArgs e)
        {
            DateTime current = new DateTime();
            current = System.DateTime.Now;
            current = current.AddDays(-1);
            if (e.Day.Date < current)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Gray;
            }
        }
        private void renderPending(Object sender, DayRenderEventArgs e)
        {
            SqlConnection pendingDB = new SqlConnection(connString);
            SqlCommand cmd;

            try
            {
                pendingDB.Open();
                cmd = new SqlCommand("SELECT checkIn, nights FROM Pending WHERE roomID = @roomID", pendingDB);
                cmd.Parameters.AddWithValue("@roomID", currentPending);

                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    DateTime checkInDate = Convert.ToDateTime(read[0].ToString());
                    double numNights = Convert.ToDouble(read[1].ToString());
                    DateTime checkOutDate = checkInDate.AddDays(numNights - 1);

                    if (checkInDate <= e.Day.Date && checkOutDate >= e.Day.Date)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Green;
                        e.Day.IsSelectable = false;
                    }
                }
                read.Close();
            }
            catch (Exception error)
            {
                Session["error"] = "rendarPending() : ERROR : " + error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                pendingDB.Close();
            }

        }
        private void renderReserved(Object sender, DayRenderEventArgs e)
        {
            SqlConnection reservedDB = new SqlConnection(connString);
            SqlCommand cmd;

            try
            {
                reservedDB.Open();
                cmd = new SqlCommand("SELECT checkIn, nights FROM Reserved WHERE roomID = @roomID", reservedDB);
                cmd.Parameters.AddWithValue("@roomID", currentPending);

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DateTime checkInDate = Convert.ToDateTime(read[0].ToString());
                    double numNights = Convert.ToDouble(read[1].ToString());
                    DateTime checkOutDate = checkInDate.AddDays(numNights - 1);

                    if (checkInDate <= e.Day.Date && checkOutDate >= e.Day.Date)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Red;
                        e.Day.IsSelectable = false;
                    }
                }
                read.Close();
            }
            catch (Exception error)
            {
                Session["error"] = "rendarReserved() : ERROR : " + error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                reservedDB.Close();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;

            Session["pending"] = GridView1.Rows[index].Cells[6].Text;
            currentPending = Convert.ToInt32(GridView1.Rows[index].Cells[1].Text);

            customers.SelectParameters["ID"].DefaultValue = GridView1.Rows[index].Cells[4].Text;
            pendingDetails.SelectParameters["ID"].DefaultValue = GridView1.Rows[index].Cells[6].Text;

            lblCustomer.Visible = true;
            lblReservation.Visible = true;
            DetailsView1.Visible = true;
            DetailsView2.Visible = true;
            confirmPending.Visible = true;
            deletePending.Visible = true;
            cancel.Visible = true;
            
        }
        protected void confirmPending_Click(object sender, EventArgs e)
        {
            Reservation confirm = getDetails(currentPending);

            if (confirm.roomID > 0)
            {
                insertReservation(confirm);
            }

            GridView1.Enabled = false;
            GridView1.DataBind();
            GridView1.Enabled = true;
            Response.Redirect(Request.RawUrl);
        }
        private Reservation getDetails(int pendingID)
        {
            //test.Text = pendingID.ToString();
            Reservation confirmed = new Reservation();
            confirmed.roomID = -1;

            SqlConnection pendingDB = new SqlConnection(connString);
            SqlCommand cmd;

            pendingID = Convert.ToInt32(Session["pending"]);

            try
            {
                pendingDB.Open();
                cmd = new SqlCommand("SELECT roomID,checkIn,nights,custID,message FROM Pending WHERE id = @pendingID", pendingDB);
                cmd.Parameters.AddWithValue("@PendingID", pendingID);

                SqlDataReader read = cmd.ExecuteReader();

               if(read.Read())
                {
                    confirmed.roomID = Convert.ToInt32(read[0].ToString());
                    confirmed.checkIn = Convert.ToDateTime(read[1].ToString());
                    confirmed.nights = Convert.ToInt32(read[2].ToString());
                    confirmed.custID = Convert.ToInt32(read[3].ToString());
                    confirmed.message = read[4].ToString();
                }
                return confirmed;
            }
            catch (Exception error)
            {
                Session["error"] = "getDetails() : ERROR : " + error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                pendingDB.Close();    
            }
            return confirmed;
        }
        private void insertReservation(Reservation confirm)
        {
            SqlConnection reservedDB = new SqlConnection(connString);
            SqlCommand cmd;

            try
            {
                reservedDB.Open();
                if (confirm.message == "")
                {
                    cmd = new SqlCommand("INSERT INTO Reserved (roomID,checkIn,nights,custID) VALUES (@roomID,@checkIn,@nights,@custID)", reservedDB);
                    cmd.Parameters.AddWithValue("@roomID", confirm.roomID);
                    cmd.Parameters.AddWithValue("@checkIn", confirm.checkIn);
                    cmd.Parameters.AddWithValue("@nights", confirm.nights);
                    cmd.Parameters.AddWithValue("@custID", confirm.custID);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Reserved (roomID,checkIn,nights,custID,message) VALUES (@roomID,@checkIn,@nights,@custID,@message)", reservedDB);
                    cmd.Parameters.AddWithValue("@roomID", confirm.roomID);
                    cmd.Parameters.AddWithValue("@checkIn", confirm.checkIn);
                    cmd.Parameters.AddWithValue("@nights", confirm.nights);
                    cmd.Parameters.AddWithValue("@custID", confirm.custID);
                    cmd.Parameters.AddWithValue("@message", confirm.message);
                }

                if(cmd.ExecuteNonQuery() > 0)
                    removePending(currentPending);
            }
            catch (Exception error)
            {
                Session["error"] = "getDetails() : ERROR : " + error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                reservedDB.Close();
            }
        }
        private void removePending(int id)
        {
            SqlConnection pendingDB = new SqlConnection(connString);
            SqlCommand cmd;

            id = Convert.ToInt32(Session["pending"]);

            try
            {
                pendingDB.Open();
                
                cmd = new SqlCommand("DELETE FROM Pending WHERE id = @id", pendingDB);
                cmd.Parameters.AddWithValue("@id", id);                

                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                Session["error"] = "getDetails() : ERROR : " + error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                pendingDB.Close();
            }
        }
        protected void dllRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPending = Convert.ToInt32(dllRooms.SelectedValue);
        }
        protected void deletePending_Click(object sender, EventArgs e)
        {
            removePending(Convert.ToInt32(Session["pending"]));
            GridView1.Enabled = false;
            GridView1.DataBind();
            GridView1.Enabled = true;
            Response.Redirect(Request.RawUrl);
        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}