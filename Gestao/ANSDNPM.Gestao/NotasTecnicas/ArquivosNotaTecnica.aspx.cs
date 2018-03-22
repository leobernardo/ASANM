using System;
using System.Configuration;
using System.Linq;
using System.IO;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.NotasTecnicas
{
    public partial class ArquivosNotaTecnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArquivoNotaTecnicaDAL antDAL = new ArquivoNotaTecnicaDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        ArquivoNotaTecnica ant = antDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idAnt"]));

                        string strCaminho = ConfigurationManager.AppSettings["path"] + @"\NotasTecnicas\";

                        if (File.Exists(strCaminho + ant.NMArquivo))
                        { File.Delete(strCaminho + ant.NMArquivo); }

                        antDAL.Excluir(ant);

                        Response.Write("<script language='JavaScript'>alert('Arquivo da Nota Técnica excluído com sucesso');location='ArquivosNotaTecnica.aspx?idNtt=" + ant.NotaTecnica.IDNotaTecnica + "';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS ARQUIVOS DA NOTA TÉCNICA //
                rptArquivosNotaTecnica.DataSource = antDAL.Listar().Cast<ArquivoNotaTecnica>().Where(nt => nt.NotaTecnica.IDNotaTecnica == Convert.ToInt32(Request.QueryString["idNtt"]));
                rptArquivosNotaTecnica.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarArquivoNotaTecnica(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarArquivoNotaTecnica.aspx?idNtt=" + Request.QueryString["idNtt"]); }
            catch (Exception ex)
            { throw; }
        }
    }
}