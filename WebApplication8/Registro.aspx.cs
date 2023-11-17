using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication8
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("email", TextBox4.Text);
            Response.Cookies.Add(cookie);
            this.Session["usuario"] = TextBox1.Text;
            Response.Redirect(Request.RawUrl);
        }

        
    }
}