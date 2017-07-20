using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace IP_FinalProject
{
    public partial class LogIn : System.Web.UI.Page
    {
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["CondoRoomsConnectionString"].ConnectionString;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["validUser"]))
            {
                this.Page.MasterPageFile = "~/MasterPages/Admin.Master";
            }
            else this.Page.MasterPageFile = "~/MasterPages/Template.Master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            SqlConnection admins = new SqlConnection(connString);
            SqlCommand cmd;
            admins.Open();
            cmd = new SqlCommand("SELECT Password FROM Administrators WHERE Username = @user",admins);
            cmd.Parameters.AddWithValue("@user", usernametxt.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                Session["validUser"] = false;
                lblError.Text = "* User doesn't exist";
                usernametxt.Text = "";
                passwordtxt.Text = "";
                lblError.Visible = true;
            }
            else
            {
                if (reader[0].ToString() == passwordtxt.Text)
                {
                    Session["validUser"] = true;
                    Response.Redirect("ConfirmRentals.aspx");
                }
                else
                {
                    Session["validUser"] = false;
                    lblError.Text = "* Invalid Password";
                    lblError.Visible = true;
                }
            }                      
        }
        private Boolean authenticateLogIn(String username, String password){
                        lblError.Visible = false;

            SqlConnection admins = new SqlConnection("Data Source=jmartin-lt\\sqlexpress;Initial Catalog=Condos;Integrated Security=True");
            SqlCommand cmd;
            admins.Open();
            cmd = new SqlCommand("SELECT Password FROM Administrators WHERE Username = @user", admins);
            cmd.Parameters.AddWithValue("@user", usernametxt.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                lblError.Text = "* User doesn't exist";
                usernametxt.Text = "";
                passwordtxt.Text = "";
                lblError.Visible = true;
                return false;
            }
            else
            {
                if (reader[0].ToString() == passwordtxt.Text)
                {
                    return true;
                    //Response.Redirect("ConfirmRentals.aspx");
                }
                else
                {
                    lblError.Text = "* Invalid Password";
                    lblError.Visible = true;
                    return false;
                }
            } 
        }
    }
}