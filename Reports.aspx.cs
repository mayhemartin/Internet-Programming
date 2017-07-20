using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IP_FinalProject
{
    public partial class Reports : System.Web.UI.Page
    {
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
            
        }
    }
}