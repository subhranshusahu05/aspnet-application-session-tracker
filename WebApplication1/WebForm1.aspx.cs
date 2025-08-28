using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Application["Total_user"].ToString();

            Label2.Text = Application["Number_of_online_user"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}