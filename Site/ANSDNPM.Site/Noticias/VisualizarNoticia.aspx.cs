using System;
using System.Web.UI;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Site.Noticias
{
    public partial class VisualizarNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    NoticiaDAL nDAL = new NoticiaDAL();
                    Noticia n = nDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtc"]));

                    litTitulo.Text = n.DSTitulo;
                    litCorpo.Text = n.DSCorpo;
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}