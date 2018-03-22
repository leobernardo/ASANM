using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Site.NotasTecnicas
{
    public partial class VisualizarNotaTecnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();
                    NotaTecnica nt = ntDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtt"]));

                    litNumeroAno.Text = nt.NRNotaTecnica + "/" + nt.NRAnoNotaTecnica;
                    litTitulo.Text = nt.DSTitulo;
                    litCorpo.Text = nt.DSCorpo;

                    // LISTA OS ARQUIVOS DA NOTA TÉCNICA //
                    ArquivoNotaTecnicaDAL antDAL = new ArquivoNotaTecnicaDAL();
                    rptArquivosNotaTecnica.DataSource = antDAL.Listar().Cast<ArquivoNotaTecnica>().Where(n => n.NotaTecnica.IDNotaTecnica == nt.IDNotaTecnica);
                    rptArquivosNotaTecnica.DataBind();
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected string getArquivo(int _IdArquivoNotaTecnica)
        {
            try
            {
                ArquivoNotaTecnicaDAL antDAL = new ArquivoNotaTecnicaDAL();
                ArquivoNotaTecnica ant = antDAL.ObterDadosPorId(_IdArquivoNotaTecnica);

                return "<li><a href=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/NotasTecnicas/" + ant.NMArquivo + "\" target=\"_blank\">" + ant.DSArquivo + "</a></li>";
            }
            catch (Exception)
            { throw; }
        }
    }
}