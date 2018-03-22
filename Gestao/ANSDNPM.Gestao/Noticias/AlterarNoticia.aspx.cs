using System;
using System.Configuration;
using System.Web.UI;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Noticias
{
    public partial class AlterarNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    NoticiaDAL nDAL = new NoticiaDAL();
                    Noticia n = nDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtc"]));

                    txtTitulo.Text = n.DSTitulo;
                    ckeditor_standard.InnerText = n.DSCorpo;

                    if (n.BTAtiva == true)
                    {
                        radAtivo_N.Checked = false;
                        radAtivo_S.Checked = true;
                    }
                    else
                    {
                        radAtivo_N.Checked = true;
                        radAtivo_S.Checked = false;
                    }
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                NoticiaDAL nDAL = new NoticiaDAL();
                Noticia n = nDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtc"]));

                n.DSTitulo = txtTitulo.Text;
                n.DSCorpo = ckeditor_standard.InnerText;

                if (radAtivo_N.Checked)
                { n.BTAtiva = false; }
                else
                { n.BTAtiva = true; }

                nDAL.Alterar(n);

                #region IMAGEM
                if (txtImagem.HasFile)
                {
                    switch (txtImagem.FileName.Substring(txtImagem.FileName.Length - 4))
                    {
                        case ".jpg":
                            string strNome;

                            strNome = n.IDNoticia + txtImagem.FileName.Substring(txtImagem.FileName.Length - 4);
                            n.DSArquivoImagem = strNome;

                            txtImagem.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Noticias\" + strNome);

                            nDAL.Alterar(n);

                            break;
                        default:
                            break;
                    }
                }
                #endregion

                Response.Write("<script language='JavaScript'>alert('Notícia alterada com sucesso');window.parent.location='ListarNoticias.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}