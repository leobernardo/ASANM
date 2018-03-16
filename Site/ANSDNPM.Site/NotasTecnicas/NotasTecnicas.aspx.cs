using System;
using System.Linq;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Site.NotasTecnicas
{
    public partial class NotasTecnicas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // LISTA AS NOTAS TÉCNICAS //
                NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();
                rptNotasTecnicas.DataSource = ntDAL.Listar().Cast<NotaTecnica>().Where(a => a.BTAtiva == true).OrderByDescending(n => n.NRNotaTecnica).OrderByDescending(a => a.NRAnoNotaTecnica);
                rptNotasTecnicas.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }
    }
}