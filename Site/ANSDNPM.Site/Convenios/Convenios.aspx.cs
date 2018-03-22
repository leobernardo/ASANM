using System;
using System.Linq;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Site.Convenios
{
    public partial class Convenios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ConvenioDAL cDAL = new ConvenioDAL();

                if (Request.QueryString["uf"] != null)
                {
                    // LISTA OS CONVÊNIOS DA UF //
                    rptConveniosUF.DataSource = cDAL.Listar().Cast<Convenio>().Where(u => u.UFConvenio == Convert.ToString(Request.QueryString["uf"]).ToUpper()).OrderBy(n => n.NMConvenio);
                    rptConveniosUF.DataBind();
                    // FIM //

                    litUFConvenio.Text = Convert.ToString(Request.QueryString["uf"]).ToUpper();

                    if (cDAL.Listar().Cast<Convenio>().Where(u => u.UFConvenio == Convert.ToString(Request.QueryString["uf"]).ToUpper()).Count() == 0)
                    { Response.Write("<script language='JavaScript'>alert('Infelizmente, esta UF ainda não possui nenhum convênio local firmado');window.parent.location='Convenios.aspx';</script>"); }
                    else
                    { divUFConvenio.Visible = true; }
                }

                // LISTA OS CONVÊNIOS NACIONAIS //
                rptConveniosNacionais.DataSource = cDAL.Listar().Cast<Convenio>().Where(u => u.UFConvenio == "BR").OrderBy(n => n.NMConvenio);
                rptConveniosNacionais.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }
    }
}