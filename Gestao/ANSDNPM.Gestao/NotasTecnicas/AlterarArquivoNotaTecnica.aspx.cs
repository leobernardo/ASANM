using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.NotasTecnicas
{
    public partial class AlterarArquivoNotaTecnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ArquivoNotaTecnicaDAL antDAL = new ArquivoNotaTecnicaDAL();
                    ArquivoNotaTecnica ant = antDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idAnt"]));

                    txtDescricao.Text = ant.DSArquivo;
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                ArquivoNotaTecnicaDAL antDAL = new ArquivoNotaTecnicaDAL();
                ArquivoNotaTecnica ant = antDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idAnt"]));

                if (txtArquivo.HasFile)
                {
                    switch (txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4))
                    {
                        case "docx":
                        case ".doc":
                        case ".pdf":
                            string strNome, strExtensao;

                            if (txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4) == "docx")
                            { strExtensao = ".docx"; }
                            else
                            { strExtensao = txtArquivo.FileName.Substring(txtArquivo.FileName.Length - 4); }

                            strNome = ant.IDArquivoNotaTecnica + strExtensao;

                            ant.NMArquivo = strNome;

                            txtArquivo.SaveAs(ConfigurationManager.AppSettings["path"] + @"\NotasTecnicas\" + strNome);

                            antDAL.Alterar(ant);

                            Response.Write("<script language='JavaScript'>alert('Arquivo da Nota Técnica alterado com sucesso');window.location='ArquivosNotaTecnica.aspx?idNtt=" + ant.NotaTecnica.IDNotaTecnica + "';</script>");

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    ant.DSArquivo = Util.formataTexto(txtDescricao.Text, false);

                    antDAL.Alterar(ant);

                    Response.Write("<script language='JavaScript'>alert('Arquivo da Nota Técnica alterado com sucesso');window.location='ArquivosNotaTecnica.aspx?idNtt=" + ant.NotaTecnica.IDNotaTecnica + "';</script>");
                }
            }
            catch (Exception)
            { throw; }
        }
    }
}