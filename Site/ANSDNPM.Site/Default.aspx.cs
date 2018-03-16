using System;

namespace ANSDNPM.Site
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { Response.Redirect("Home/Home.aspx"); }
    }
}