using System;
using System.Configuration;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.NotasTecnicas
{
    public partial class CadastrarArquivoNotaTecnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                ArquivoNotaTecnica ant = new ArquivoNotaTecnica();

                NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();
                ant.NotaTecnica = ntDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtt"]));
                ant.NMArquivo = "";
                ant.DSArquivo = Util.formataTexto(txtDescricao.Text, false);

                ArquivoNotaTecnicaDAL antDAL = new ArquivoNotaTecnicaDAL();
                antDAL.Cadastrar(ant);

                if (txtArquivo.HasFile)
                {
                    switch (txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4))
                    {
                        case "docx":
                        case ".doc":
                        case ".pdf":
                            ArquivoNotaTecnica antUltimo = antDAL.ObterDadosUltimoCadastrado();

                            string strNome, strExtensao;

                            if (txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4) == "docx")
                            { strExtensao = ".docx"; }
                            else
                            { strExtensao = txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4); }

                            strNome = antUltimo.IDArquivoNotaTecnica + strExtensao;
                            antUltimo.NMArquivo = strNome;

                            txtArquivo.SaveAs(ConfigurationManager.AppSettings["path"] + @"\NotasTecnicas\" + strNome);

                            antDAL.Alterar(antUltimo);

                            Response.Write("<script language='JavaScript'>alert('Arquivo da Nota Técnica cadastrado com sucesso');window.location='ArquivosNotaTecnica.aspx?idNtt=" + ant.NotaTecnica.IDNotaTecnica + "';</script>");

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