using System;
using System.Configuration;
using System.Linq;
using System.IO;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Convenios
{
    public partial class ArquivosConvenio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArquivoConvenioDAL acDAL = new ArquivoConvenioDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        ArquivoConvenio ac = acDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idAcn"]));

                        string strCaminho = ConfigurationManager.AppSettings["path"] + @"\Convenios\";

                        if (File.Exists(strCaminho + ac.NMArquivo))
                        { File.Delete(strCaminho + ac.NMArquivo); }

                        acDAL.Excluir(ac);

                        Response.Write("<script language='JavaScript'>alert('Arquivo do Convênio excluído com sucesso');location='ArquivosConvenio.aspx?idCnv=" + ac.Convenio.IDConvenio + "';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS ARQUIVOS DO CONVÊNIO //
                rptArquivosConvenio.DataSource = acDAL.Listar().Cast<ArquivoConvenio>().Where(c => c.Convenio.IDConvenio == Convert.ToInt32(Request.QueryString["idCnv"]));
                rptArquivosConvenio.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarArquivoConvenio(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarArquivoConvenio.aspx?idCnv=" + Request.QueryString["idCnv"]); }
            catch (Exception ex)
            { throw; }
        }
    }
}