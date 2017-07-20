using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Web.Script.Serialization;

namespace IP_FinalProject
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["validUser"]))
            {
                this.Page.MasterPageFile = "~/MasterPages/AdminDefault.Master";
            }
            else this.Page.MasterPageFile = "~/MasterPages/Template.Master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            fromtxt.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");
            subjecttxt.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");
            messagetxt.Attributes.Add("onFocus", "this.value=''; this.style.color = 'Black';");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblNotify.Text = "Sending....";
            lblNotify.Visible = true;

            if (checkRequired() && checkValid())
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(fromtxt.Text);
                msg.To.Add(new MailAddress("jmartin1.islander.tamucc.mail@gmail.com"));
                msg.Subject = subjecttxt.Text;
                msg.Body = messagetxt.Text;

                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = new NetworkCredential("jmartin1.islander.tamucc.mail@gmail.com", "COSC3351");
                    client.EnableSsl = true;
                    client.Send(msg);

                    btnSubmit.Visible = false;
                    lblNotify.Text = "Your message has been sent. We will contact you shortly.";
                }
                catch
                {
                    lblNotify.Text = "ERROR: Could not send message.";
                }
            }
            else
            {

            }
            
        }
        private Boolean checkValid()
        {
            int errors = 0;

            if (!(fromtxt.Text).Contains("@"))
            {
                fromtxt.ForeColor = System.Drawing.Color.Red;
                fromtxt.Text = "*Invalid Email Address";
                errors++;
            }

            if (errors > 0)
                return false;

            else return true;
        }
        private Boolean checkRequired()
        {
            int errors = 0;

            if (fromtxt.Text == "")
            {
                fromtxt.ForeColor = System.Drawing.Color.Red;
                fromtxt.Text = "*Required";

                errors++;
            }

            if (subjecttxt.Text == "")
            {
                subjecttxt.ForeColor = System.Drawing.Color.Red;
                subjecttxt.Text = "*Required";

                errors++;
            }

            if (messagetxt.Text == "")
            {
                messagetxt.ForeColor = System.Drawing.Color.Red;
                messagetxt.Text = "*Required";

                errors++;
            }

            if (errors > 0)
                return false;

            else return true;
        }
    }
}