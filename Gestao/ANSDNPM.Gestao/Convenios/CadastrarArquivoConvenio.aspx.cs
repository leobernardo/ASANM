using System;
using System.Configuration;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Convenios
{
    public partial class CadastrarArquivoConvenio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                ArquivoConvenio ac = new ArquivoConvenio();

                ConvenioDAL cDAL = new ConvenioDAL();
                ac.Convenio = cDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idCnv"]));
                ac.NMArquivo = "";
                ac.DSArquivo = Util.formataTexto(txtDescricao.Text, false);

                ArquivoConvenioDAL acDAL = new ArquivoConvenioDAL();
                acDAL.Cadastrar(ac);

                if (txtArquivo.HasFile)
                {
                    switch (txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4))
                    {
                        case ".pdf":
                            ArquivoConvenio acUltimo = acDAL.ObterDadosUltimoCadastrado();

                            string strNome;

                            strNome = acUltimo.IDArquivoConvenio + txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4);
                            acUltimo.NMArquivo = strNome;

                            txtArquivo.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Convenios\" + strNome);

                            acDAL.Alterar(acUltimo);

                            Response.Write("<script language='JavaScript'>alert('Arquivo do Convênio cadastrado com sucesso');window.location='ArquivosConvenio.aspx?idCnv=" + ac.Convenio.IDConvenio + "';</script>");

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}