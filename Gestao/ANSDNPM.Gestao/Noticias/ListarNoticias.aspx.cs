using System;
using System.Configuration;
using System.Linq;
using System.IO;

using ImageResizer;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Noticias
{
    public partial class ListarNoticias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NoticiaDAL nDAL = new NoticiaDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Noticia n = nDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtc"]));

                        string strCaminho = ConfigurationManager.AppSettings["path"];

                        if (File.Exists(strCaminho + "/Capas/cp_" + n.DSArquivoImagem))
                        { File.Delete(strCaminho + "/Capas/cp_" + n.DSArquivoImagem); }

                        if (File.Exists(strCaminho + "/Thumbs/tb_" + n.DSArquivoImagem))
                        { File.Delete(strCaminho + "/Thumbs/tb_" + n.DSArquivoImagem); }

                        if (File.Exists(strCaminho + n.DSArquivoImagem))
                        { File.Delete(strCaminho + n.DSArquivoImagem); }

                        nDAL.Excluir(n);
                        Response.Write("<script language='JavaScript'>alert('Notícia excluída com sucesso');location='ListarNoticias.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA AS NOTÍCIAS //
                rptNoticias.DataSource = nDAL.Listar();
                rptNoticias.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarNoticia(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarNoticia.aspx"); }
            catch (Exception)
            { throw; }
        }

        protected string getAtivo(bool _Ativo)
        {
            try
            { return Util.getAtivo(_Ativo); }
            catch (Exception)
            { throw; }
        }

        protected string getImagem(int _IdNoticia)
        {
            try
            {
                NoticiaDAL nDAL = new NoticiaDAL();
                Noticia n = nDAL.ObterDadosPorId(_IdNoticia);

                if (!string.IsNullOrEmpty(n.DSArquivoImagem))
                {
                    string strExtensao = n.DSArquivoImagem.Substring(n.DSArquivoImagem.Length - 3);

                    ResizeSettings resizeCropSettings_Capa = new ResizeSettings("width=457&height=343&format=" + strExtensao + "&crop=auto");
                    ResizeSettings resizeCropSettings_Thumb = new ResizeSettings("width=100&height=100&format=" + strExtensao + "&crop=auto");

                    string capa = Path.Combine(ConfigurationManager.AppSettings["path"], System.Guid.NewGuid().ToString());
                    capa = ImageBuilder.Current.Build(ConfigurationManager.AppSettings["path"] + @"\Noticias\" + n.DSArquivoImagem, ConfigurationManager.AppSettings["path"] + "/Noticias/Capas/cp_" + n.IDNoticia, resizeCropSettings_Capa, false, true);

                    string thumb = Path.Combine(ConfigurationManager.AppSettings["path"], System.Guid.NewGuid().ToString());
                    thumb = ImageBuilder.Current.Build(ConfigurationManager.AppSettings["path"] + @"\Noticias\" + n.DSArquivoImagem, ConfigurationManager.AppSettings["path"] + "/Noticias/Thumbs/tb_" + n.IDNoticia, resizeCropSettings_Thumb, false, true);

                    return "<img src=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Noticias/Thumbs/tb_" + n.DSArquivoImagem + "\" />";
                }
                else
                { return ""; }
            }
            catch (Exception)
            { throw; }
        }
    }
}