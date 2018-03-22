using System;
using System.Configuration;
using System.Linq;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Site.MasterPages
{
    public partial class mpASANM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // LISTA AS ÚLTIMAS FOTOS //
                FotoGaleriaDAL fgDAL = new FotoGaleriaDAL();
                rptUltimasFotos.DataSource = fgDAL.Listar().Cast<FotoGaleria>().OrderByDescending(i => i.IDFotoGaleria).Take(6);
                rptUltimasFotos.DataBind();
                // FIM //

                // LISTA AS ÚLTIMAS NOTAS TÉCNICAS //
                NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();
                rptUltimasNotasTecnicas.DataSource = ntDAL.Listar().Cast<NotaTecnica>().Where(a => a.BTAtiva == true).OrderByDescending(n => n.NRNotaTecnica).OrderByDescending(a => a.NRAnoNotaTecnica).Take(10);
                rptUltimasNotasTecnicas.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected string getFoto(int _IdFotoGaleria)
        {
            try
            {
                FotoGaleriaDAL fgDAL = new FotoGaleriaDAL();
                FotoGaleria fg = fgDAL.ObterDadosPorId(_IdFotoGaleria);

                return "<a href=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Galerias/" + fg.DSArquivoFoto + "\" class=\"foto\"><img src=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Galerias/Temp/Temp_" + fg.DSArquivoFoto + "\" alt=\"\" /></a> ";
            }
            catch (Exception)
            { throw; }
        }
    }
}