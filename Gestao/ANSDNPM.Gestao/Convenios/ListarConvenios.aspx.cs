using System;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Convenios
{
    public partial class ListarConvenios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ConvenioDAL cDAL = new ConvenioDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Convenio c = cDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idCnv"]));
                        cDAL.Excluir(c);
                        Response.Write("<script language='JavaScript'>alert('Convênio excluído com sucesso');location='ListarConvenios.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS CONVÊNIOS //
                rptConvenios.DataSource = cDAL.Listar();
                rptConvenios.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarConvenio(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarConvenio.aspx"); }
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
    }
}