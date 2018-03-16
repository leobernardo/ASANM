using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Site.Comunicacoes
{
    public partial class VisualizarArtigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ArtigoDAL aDAL = new ArtigoDAL();
                    Artigo a = aDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idArt"]));

                    litTitulo.Text = a.DSTitulo;
                    litCorpo.Text = a.DSCorpo;
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}