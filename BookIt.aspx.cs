using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data.SqlClient;


namespace IP_FinalProject
{
    public partial class BookIt : System.Web.UI.Page
    {
        String room;
        public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
        List<String> pending = new List<String>();
        List<String> reserved = new List<String>();
        List<DateTime> dates = new List<DateTime>();

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
            room = Convert.ToString(Session["roomValue"]);

            email.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");
            firstName.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");
            lastName.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");
            mssg.Attributes.Add("onFocus", "this.value='';");
            primaryNumber.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");
            cellNumber.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");

            if (!IsPostBack)
            {
                for (int x = 0; x < 22; x++)
                {
                    dllNights.Items.Insert(x, new ListItem((x + 1).ToString()));
                }

                dllNights.SelectedIndex = 0;
                
                loadBlockOutDates();
                DateTime current = new DateTime();
                current = System.DateTime.Now;
            
                while (pending.Contains(current.ToString("MM-dd-yyyy")) || reserved.Contains(current.ToString("MM-dd-yyyy")))
                {
                    current = current.AddDays(1);
                }
                checkIn.Text = current.ToString("MM-dd-yyyy");
            }
        }
        public String getRoom(){
            return room;
        }
        protected void checkInBigCalendar_DayRender(Object sender, DayRenderEventArgs e)
        {
            renderPending(sender,e);
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
            SqlConnection pendingDB = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condo;Integrated Security=True");
            SqlCommand cmd;

            try
            {
                pendingDB.Open();
                cmd = new SqlCommand("SELECT checkIn, nights FROM Pending WHERE roomID = @roomID", pendingDB);
                cmd.Parameters.AddWithValue("@roomID", room);

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
                

            }
            catch (Exception error)
            {
                Session["error"] = "rendarPending() : ERROR : "+error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                pendingDB.Close();
            }
            
        }
        private void renderReserved(Object sender, DayRenderEventArgs e)
        {
            SqlConnection reservedDB = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condo;Integrated Security=True");
            SqlCommand cmd;

            try
            {
                reservedDB.Open();
                cmd = new SqlCommand("SELECT checkIn, nights FROM Reserved WHERE roomID = @roomID", reservedDB);
                cmd.Parameters.AddWithValue("@roomID", room);

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
                
            }
            catch (Exception error)
            {
                Session["error"] = "rendarReserved() : ERROR : "+error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                reservedDB.Close();
            }
        }
        private void loadBlockOutDates()
        {
            loadPending();
            loadReserved();
        }
        private void loadPending()
        {
            SqlConnection pendingDB = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condo;Integrated Security=True");
            SqlCommand cmdPending;

            try
            {
                pendingDB.Open();
                cmdPending = new SqlCommand("SELECT checkIn, nights FROM Pending WHERE roomID = @roomID", pendingDB);
                cmdPending.Parameters.AddWithValue("@roomID", room);

                SqlDataReader readPending = cmdPending.ExecuteReader();

                while (readPending.Read())
                {
                    DateTime checkInDate = Convert.ToDateTime(readPending[0].ToString());
                    double numNights = Convert.ToDouble(readPending[1].ToString());
                    DateTime checkOutDate = checkInDate.AddDays(numNights-1);

                    while (checkInDate <= checkOutDate)
                    {
                        String temp = checkInDate.ToString("MM-dd-yyyy");
                        pending.Add(temp);
                        checkInDate = checkInDate.AddDays(1);
                    }
                }
            }
            catch (Exception error)
            {
                Session["error"] = "loadPending() : ERROR : "+error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                pendingDB.Close();
            }
        }
        private void loadReserved()
        {
            SqlConnection reservedDB = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condo;Integrated Security=True");
            SqlCommand cmdReserved;
            try
            {
                reservedDB.Open();
                cmdReserved = new SqlCommand("SELECT checkIn, nights FROM Reserved WHERE roomID = @roomID", reservedDB);
                cmdReserved.Parameters.AddWithValue("@roomID", room);

                SqlDataReader readReserved = cmdReserved.ExecuteReader();

                while (readReserved.Read())
                {
                    DateTime checkInDate = Convert.ToDateTime(readReserved[0].ToString());
                    double numNights = Convert.ToDouble(readReserved[1].ToString());
                    DateTime checkOutDate = checkInDate.AddDays(numNights-1);

                    while (checkInDate <= checkOutDate)
                    {
                        String temp = checkInDate.ToString("MM-dd-yyyy");
                        reserved.Add(temp);
                        checkInDate = checkInDate.AddDays(1);
                    }
                }


            }
            catch (Exception error)
            {
                Session["error"] = "loadReserved() : ERROR : "+error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                reservedDB.Close();
            }
        }
        private void loadBox(String var, TextBox textBox)
        {
            if (Session[var].ToString() == null || Session[var].ToString() == "")
            {
                textBox.Text = "";
            }
            else textBox.Text = Session[var].ToString();
        }

        protected void checkInCalendar_Click(object sender, ImageClickEventArgs e)
        {
            checkInCalendar.Visible = false;
            checkInBigCalendar.Visible = true;
            pendingKey.Visible = true;
            reservedKey.Visible = true;
        }
        protected void checkInBigCalendar_SelectionChanged(object sender, EventArgs e)
        {
            checkIn.Text = checkInBigCalendar.SelectedDate.ToString("MM-dd-yyyy");
            checkInCalendar.Visible = true;
            checkInBigCalendar.Visible = false;
            pendingKey.Visible = false;
            reservedKey.Visible = false;
        }

        protected void reserve_Click(object sender, EventArgs e)
        {
            if (checkRequired() && checkValid())
            {
                DateTime temp = (DateTime.Parse(checkIn.Text)).AddDays(Convert.ToDouble(dllNights.SelectedValue));

                Session["checkInDate"] = checkIn.Text;
                Session["checkOutDate"] = temp.ToString("MM-dd-yyyy");
                Session["numNights"] = dllNights.SelectedIndex + 1;
                Session["firstName"] = firstName.Text;
                Session["lastName"] = lastName.Text;
                Session["primaryPhone"] = primaryNumber.Text;
                Session["secondaryPhone"] = cellNumber.Text;
                Session["email"] = email.Text;

                if ((mssg.Text).Equals("Enter a message for our staff."))
                {
                    Session["message"] = "";
                }
                else Session["message"] = mssg.Text;

                Response.Redirect("~/Confirmation.aspx");
            }
        }
        private Boolean checkRequired()
        {
            int errors = 0;

            if (email.Text == "")
            {
                email.ForeColor = System.Drawing.Color.Red;
                email.Text = "*Required";

                errors++;
            }
            if(firstName.Text == ""){
                firstName.ForeColor = System.Drawing.Color.Red;
                firstName.Text = "*Required";

                errors++;
            }
            if (lastName.Text == "")
            {
                lastName.ForeColor = System.Drawing.Color.Red;
                lastName.Text = "*Required";

                errors++;
            }
            if (primaryNumber.Text == "")
            {
                primaryNumber.ForeColor = System.Drawing.Color.Red;
                primaryNumber.Text = "*Required";

                errors++;
            }

            if (errors > 0)
                return false;

            else return true;
            
        }
        private Boolean checkValid()
        {
            int errors = 0;

            if (!(email.Text).Contains("@"))
            {
                email.ForeColor = System.Drawing.Color.Red;
                email.Text = "*Invalid email address";
                errors++;
            }
            if(!isAlpha(firstName.Text)){
                firstName.ForeColor = System.Drawing.Color.Red;
                firstName.Text = "*Invalid Name";
                errors++;
            }
            if (!isAlpha(lastName.Text))
            {
                lastName.ForeColor = System.Drawing.Color.Red;
                lastName.Text = "*Invalid Name";
                errors++;
            }

            if (errors > 0)
                return false;

            else return true;
        }
        private Boolean isAlpha(String text)
        {
            for(int x=0; x < text.Length; x++)
            {
                if(!(char.IsLetter(text[x])))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}