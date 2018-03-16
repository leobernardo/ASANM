using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ANSDNPM.Gestao.MasterPages
{
    public partial class mpANSDNPM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["sesIDUsuario"] == null)
                { Response.Redirect("../Login.aspx"); }
            }
            catch (Exception)
            { throw; }
        }
    }
}