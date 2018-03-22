using System;
using System.Linq;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Site.Noticias
{
    public partial class Noticias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // LISTA AS NOTÍCIAS //
                NoticiaDAL nDAL = new NoticiaDAL();
                rptNoticias.DataSource = nDAL.Listar().Cast<Noticia>().Where(a => a.BTAtiva == true);
                rptNoticias.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }
    }
}