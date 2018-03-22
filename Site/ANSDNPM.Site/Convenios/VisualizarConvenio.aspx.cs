using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Site.Convenios
{
    public partial class VisualizarConvenio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ConvenioDAL cDAL = new ConvenioDAL();
                    Convenio c = cDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idCnv"]));

                    litNome.Text = c.NMConvenio;
                    litDescricao.Text = c.DSConvenio;

                    // LISTA OS ARQUIVOS DO CONVÊNIO //
                    ArquivoConvenioDAL acDAL = new ArquivoConvenioDAL();
                    rptArquivosConvenio.DataSource = acDAL.Listar().Cast<ArquivoConvenio>().Where(cv => cv.Convenio.IDConvenio == c.IDConvenio);
                    rptArquivosConvenio.DataBind();
                    // FIM //
                }
            }
            catch (Exception)
            { throw; }
        }

        protected string getArquivo(int _IdArquivoConvenio)
        {
            try
            {
                ArquivoConvenioDAL acDAL = new ArquivoConvenioDAL();
                ArquivoConvenio ac = acDAL.ObterDadosPorId(_IdArquivoConvenio);

                return "<li><a href=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Convenios/" + ac.NMArquivo + "\" target=\"_blank\">" + ac.DSArquivo + "</a></li>";
            }
            catch (Exception)
            { throw; }
        }
    }
}