using System;
using System.Configuration;
using System.Linq;
using System.IO;

using ImageResizer;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Galerias
{
    public partial class FotosGaleria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                FotoGaleriaDAL fgDAL = new FotoGaleriaDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        FotoGaleria fg = fgDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idFot"]));

                        string strCaminho = ConfigurationManager.AppSettings["path"];

                        if (File.Exists(strCaminho + "/Temp/Temp_" + fg.DSArquivoFoto))
                        { File.Delete(strCaminho + "/Temp/Temp_" + fg.DSArquivoFoto); }

                        if (File.Exists(strCaminho + fg.DSArquivoFoto))
                        { File.Delete(strCaminho + fg.DSArquivoFoto); }

                        fgDAL.Excluir(fg);

                        Response.Write("<script language='JavaScript'>alert('Foto da Galeria excluída com sucesso');location='FotosGaleria.aspx?idGlr=" + fg.Galeria.IDGaleria + "';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA AS FOTOS DA GALERIA //
                rptFotosGaleria.DataSource = fgDAL.Listar().Cast<FotoGaleria>().Where(g => g.Galeria.IDGaleria == Convert.ToInt32(Request.QueryString["idGlr"]));
                rptFotosGaleria.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarFotoGaleria(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarFotoGaleria.aspx?idGlr=" + Request.QueryString["idGlr"]); }
            catch (Exception)
            { throw; }
        }

        protected string getFoto(int _IdFotoGaleria)
        {
            try
            {
                FotoGaleriaDAL fgDAL = new FotoGaleriaDAL();
                FotoGaleria fg = fgDAL.ObterDadosPorId(_IdFotoGaleria);

                ResizeSettings resizeCropSettings = new ResizeSettings("width=80&height=80&format=jpg&crop=auto");

                string fileName = Path.Combine(ConfigurationManager.AppSettings["path"], System.Guid.NewGuid().ToString());

                fileName = ImageBuilder.Current.Build(ConfigurationManager.AppSettings["path"] + @"\Galerias\" + fg.DSArquivoFoto, ConfigurationManager.AppSettings["path"] + "/Galerias/Temp/Temp_" + fg.IDFotoGaleria, resizeCropSettings, false, true);

                return "<img src=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Galerias/Temp/Temp_" + fg.DSArquivoFoto + "\" />";
            }
            catch (Exception)
            { throw; }
        }
    }
}