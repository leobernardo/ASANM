using System;
using System.Linq;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Site.Galerias
{
    public partial class Galerias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // LISTA AS GALERIAS //
                GaleriaDAL gDAL = new GaleriaDAL();
                rptGalerias.DataSource = gDAL.Listar().Cast<Galeria>().OrderByDescending(i => i.IDGaleria);
                rptGalerias.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }
    }
}