using System;
using System.Configuration;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Noticias
{
    public partial class CadastrarNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Noticia n = new Noticia();

                n.DSTitulo = txtTitulo.Text;
                n.DSCorpo = ckeditor_standard.InnerText;
                n.DSArquivoImagem = "-";

                if (radAtivo_N.Checked)
                { n.BTAtiva = false; }
                else
                { n.BTAtiva = true; }

                NoticiaDAL nDAL = new NoticiaDAL();
                nDAL.Cadastrar(n);

                Noticia nUltimo = new Noticia();
                nUltimo = nDAL.ObterDadosUltimoCadastrado();

                #region IMAGEM
                if (txtImagem.HasFile)
                {
                    switch (txtImagem.FileName.Substring(txtImagem.FileName.Length - 4))
                    {
                        case ".jpg":
                        case ".png":
                            string strNome;

                            strNome = nUltimo.IDNoticia + txtImagem.FileName.Substring(txtImagem.FileName.Length - 4);
                            nUltimo.DSArquivoImagem = strNome;

                            txtImagem.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Noticias\" + strNome);

                            nDAL.Alterar(nUltimo);

                            break;
                        default:
                            nUltimo.DSArquivoImagem = "si.png";
                            nDAL.Alterar(nUltimo);

                            break;
                    }
                }
                else
                {
                    nUltimo.DSArquivoImagem = "si.png";
                    nDAL.Alterar(nUltimo);
                }
                #endregion

                Response.Write("<script language='JavaScript'>alert('Notícia cadastrada com sucesso');window.parent.location='ListarNoticias.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}