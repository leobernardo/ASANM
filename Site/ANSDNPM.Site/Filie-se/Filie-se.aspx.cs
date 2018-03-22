using System;
using System.Configuration;

namespace ASANM.Site.Filie_se
{
    public partial class Filie_se : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string getFicha()
        {
            try
            {
                //return "<a rel=\"galeria\" href=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Galerias/" + fg.DSArquivoFoto + "\"><img src=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/Galerias/Temp/Temp_" + fg.DSArquivoFoto + "\" alt=\"\" /></a> ";
                return "<p><a href=\"" + ConfigurationManager.AppSettings["url"] + "/Arquivos/fichaFiliacao.pdf\" target=\"_blank\">Ficha de Filiação ANSDNPM</a></p>";
            }
            catch (Exception)
            { throw; }
        }
    }
}