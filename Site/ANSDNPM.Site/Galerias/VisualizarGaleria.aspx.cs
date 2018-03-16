using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Site.Galerias
{
    public partial class VisualizarGaleria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    GaleriaDAL gDAL = new GaleriaDAL();
                    Galeria g = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));

                    litDescricao.Text = g.DSGaleria;

                    // LISTA AS FOTOS DA GALERIA //
                    FotoGaleriaDAL fgDAL = new FotoGaleriaDAL();
                    rptFotosGaleria.DataSource = fgDAL.Listar().Cast<FotoGaleria>().Where(gl => gl.Galeria.IDGaleria == g.IDGaleria);
                    rptFotosGaleria.DataBind();
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected string getFoto(int _IdFotoGaleria)
        {
            try
            {
                FotoGaleriaDAL fgDAL = new FotoGaleriaDAL();
                FotoGaleria fg = fgDAL.ObterDadosPorId(_IdFotoGaleria);

                return "<a rel=\"galeria\" href=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Galerias/" + fg.DSArquivoFoto + "\"><img src=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Galerias/Temp/Temp_" + fg.DSArquivoFoto + "\" alt=\"\" /></a> ";
            }
            catch (Exception)
            { throw; }
        }
    }
}