using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace IP_FinalProject
{
    public partial class Confirmation : System.Web.UI.Page
    {
        Customer customer = new Customer();
        Reservation pending = new Reservation();
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["CondoRoomsConnectionString"].ConnectionString;

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
            customer.firstName = Convert.ToString(Session["firstName"]);
            customer.lastName = Convert.ToString(Session["lastName"]);
            customer.email = Convert.ToString(Session["email"]);
            customer.phone = Convert.ToString(Session["primaryPhone"]);
            customer.cell = Convert.ToString(Session["secondaryPhone"]);

            pending.roomID = Convert.ToInt32(Session["roomValue"]);
            pending.checkIn = Convert.ToDateTime(Session["checkInDate"]);
            pending.nights = Convert.ToInt32(Session["numNights"]);
            pending.message = Convert.ToString(Session["message"]);



            confirmRoom.Text = "Reservation Confirmation for room "+Convert.ToString(Session["roomValue"]);
            confirmCheckIn.Text = Convert.ToString(Session["checkInDate"]);
            confirmCheckOut.Text = Convert.ToString(Session["checkOutDate"]);
            confirmNumNights.Text = Convert.ToString(Session["numNights"]);
            confirmFirstName.Text = Convert.ToString(Session["firstName"]);
            confirmLastName.Text = Convert.ToString(Session["lastName"]);
            confirmPrimaryNumber.Text = Convert.ToString(Session["primaryPhone"]);
            confirmSecondaryNumber.Text = Convert.ToString(Session["secondaryPhone"]);
            confirmEmail.Text = Convert.ToString(Session["email"]);
            confirmMessage.Text = Convert.ToString(Session["message"]);
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookIt.aspx");
        }
        protected void reserve_Click(object sender, EventArgs e)
        {
            customer.ID = searchCustomer(customer.phone);

            //new customer
            if (customer.ID == 0)
            {
                insertCustomer(customer);
                customer.ID = searchCustomer(customer.phone);

                pending.custID = customer.ID;
                insertPending(pending);
                lblConfirmation.Text = "Your Reservation is Pending. We hope you enjoy your first stay with us. <br/>We will contact you within 24 hours.";
                confirm.Visible = false;
                lblConfirmation.Visible = true;
                cancel.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "alertConfirm();", true);
                
                
            }
            //existing customer
            else if (customer.ID > 0)
            {
                pending.custID = customer.ID;
                insertPending(pending);
                lblConfirmation.Text = "Your Reservation is Pending. We appreciate your continued business. <br/>We will contact you within 24 hours.";
                confirm.Visible = false;
                lblConfirmation.Visible = true;
                cancel.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "alertConfirm();", true);
            }
            //lblConfirmation.Text = "ID: " + pending.custID;
        }
        private void insertCustomer(Customer customer)
        {
            SqlConnection customerDB = new SqlConnection(connString);
            SqlCommand cmd;

            try
            {
                customerDB.Open();

                if (customer.cell == "")
                {
                    cmd = new SqlCommand("INSERT INTO Customers (firstName,lastName,email,phone) VALUES (@first,@last,@email,@phone)",customerDB);
                    cmd.Parameters.AddWithValue("@first", customer.firstName);
                    cmd.Parameters.AddWithValue("@last", customer.lastName);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@phone", customer.phone);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Customers (firstName,lastName,email,phone,cell) VALUES (@first,@last,@email,@phone,@cell)",customerDB);
                    cmd.Parameters.AddWithValue("@first", customer.firstName);
                    cmd.Parameters.AddWithValue("@last", customer.lastName);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@phone", customer.phone);
                    cmd.Parameters.AddWithValue("@cell", customer.cell);
                }

                cmd.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                Session["error"] = "insertCustomer() : ERROR : " + error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                customerDB.Close();
            }
        }
        private int searchCustomer(String primaryPhone)
        {
            SqlConnection customerDB = new SqlConnection(connString);
            SqlCommand cmd;
            int returnCode = 0;

            try
            {
                customerDB.Open();
                cmd = new SqlCommand("SELECT ID FROM Customers WHERE phone LIKE @phone",customerDB);
                cmd.Parameters.AddWithValue("@phone", primaryPhone);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    returnCode = Convert.ToInt32(read[0]);
                }
                read.Close();
            }
            catch (Exception error)
            {
                Session["error"] = "searchCustomer() : ERROR : " + error;
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                customerDB.Close();    
            }
            return returnCode;
        }
        private void insertPending(Reservation pending)
        {
            SqlConnection pendingDB = new SqlConnection(connString);
            SqlCommand cmd;

            try
            {
                pendingDB.Open();
                if (pending.message == "")
                {
                    cmd = new SqlCommand("INSERT INTO Pending (roomID,checkIn,nights,custID) VALUES (@roomID,@checkIn,@nights,@custID)", pendingDB);
                    cmd.Parameters.AddWithValue("@roomID", pending.roomID);
                    cmd.Parameters.AddWithValue("@checkIn", pending.checkIn);
                    cmd.Parameters.AddWithValue("@nights", pending.nights);
                    cmd.Parameters.AddWithValue("@custID", pending.custID);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Pending (roomID,checkIn,nights,custID,message) VALUES (@roomID,@checkIn,@nights,@custID,@message)", pendingDB);
                    cmd.Parameters.AddWithValue("@roomID", pending.roomID);
                    cmd.Parameters.AddWithValue("@checkIn", pending.checkIn);
                    cmd.Parameters.AddWithValue("@nights", pending.nights);
                    cmd.Parameters.AddWithValue("@custID", pending.custID);
                    cmd.Parameters.AddWithValue("@message", pending.message);
                }

                if (cmd.ExecuteNonQuery() <= 0)
                {
                    lblConfirmation.Text = "There was an error";
                    lblConfirmation.Visible = true;
                }
                
            }
            catch (Exception error)
            {
                Session["error"] = "insertPending() : ERROR : " + error +" Please contact us via phone to book your reservation.";
                Response.Redirect("~/Error/SqlError.aspx");
            }
            finally
            {
                pendingDB.Close();
            }
        }
    }
}