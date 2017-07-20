using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Serialization;

namespace IP_FinalProject
{
    public partial class Template : System.Web.UI.MasterPage
    {
        public String[] images;
        public JavaScriptSerializer javaSerial = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public String[] getBannerImages()
        {
            String path = Server.MapPath("/");
            path += "Images\\Banner\\";

            String[] ImagePaths = Directory.GetFiles(path);
            List<String> temp = new List<String>();

            foreach (String item in ImagePaths)
            {
                int chop = item.IndexOf("Images\\Banner\\", 0);
                temp.Add(item.Substring((chop + 14), item.Length - (chop + 14)));

            }
            images = temp.ToArray();

            return images;
        }
    }
}