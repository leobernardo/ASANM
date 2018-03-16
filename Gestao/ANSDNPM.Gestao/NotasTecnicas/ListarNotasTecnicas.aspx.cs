using System;
using System.Linq;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.NotasTecnicas
{
    public partial class ListarNotasTecnicas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        NotaTecnica nt = ntDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtt"]));
                        ntDAL.Excluir(nt);
                        Response.Write("<script language='JavaScript'>alert('Nota Técnica excluída com sucesso');location='ListarNotasTecnicas.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA AS NOTAS TÉCNICAS //
                rptNotasTecnicas.DataSource = ntDAL.Listar().Cast<NotaTecnica>().OrderByDescending(n => n.NRNotaTecnica).OrderByDescending(a => a.NRAnoNotaTecnica);
                rptNotasTecnicas.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarNotaTecnica(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarNotaTecnica.aspx"); }
            catch (Exception ex)
            { throw; }
        }

        protected string getAtivo(bool _Ativo)
        {
            try
            { return Util.getAtivo(_Ativo); }
            catch (Exception ex)
            { throw; }
        }
    }
}