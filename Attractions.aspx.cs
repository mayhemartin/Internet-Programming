using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IP_FinalProject
{
    public partial class Attractions : System.Web.UI.Page
    {
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

        }
    }
}