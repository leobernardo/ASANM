using System;
using System.Configuration;
using System.Linq;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Site.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NoticiaDAL nDAL = new NoticiaDAL();

                // OBTEM A ÚLTIMA NOTÍCIA CADASTRADA //
                Noticia nUltima = nDAL.Listar().Cast<Noticia>().OrderByDescending(i => i.IDNoticia).FirstOrDefault();
                litImagemNoticia.Text = "<a href=\"../Noticias/VisualizarNoticia.aspx?idNtc=" + nUltima.IDNoticia + "\"><img src=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Noticias/Capas/cp_" + nUltima.DSArquivoImagem + "\" alt=\"\" /></a>";
                litTituloNoticia.Text = nUltima.DSTitulo;
                // FIM //

                // LISTA AS ÚLTIMAS NOTÍCIAS //
                rptUltimasNoticias.DataSource = nDAL.Listar().Cast<Noticia>().Where(i => i.IDNoticia != nUltima.IDNoticia).Where(a => a.BTAtiva == true).OrderByDescending(i => i.IDNoticia).Take(6);
                rptUltimasNoticias.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected string getNoticia(int _IdNoticia)
        {
            try
            {
                NoticiaDAL nDAL = new NoticiaDAL();
                Noticia n = nDAL.ObterDadosPorId(_IdNoticia);

                return "<li> <a href=\"../Noticias/VisualizarNoticia.aspx?idNtc=" + n.IDNoticia + "\"><img src=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Noticias/Thumbs/tb_" + n.DSArquivoImagem + "\" alt=\"\" /></a> <a href=\"../Noticias/VisualizarNoticia.aspx?idNtc=" + n.IDNoticia + "\" class=\"title\">" + n.DSTitulo + "</a><p>" + n.DSCorpo.Substring(0, 225) + "...</p> </li>";
            }
            catch (Exception)
            { throw; }
        }
    }
}