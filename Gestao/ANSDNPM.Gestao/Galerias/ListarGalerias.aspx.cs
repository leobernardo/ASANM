using System;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Galerias
{
    public partial class ListarGalerias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GaleriaDAL gDAL = new GaleriaDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Galeria g = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));
                        gDAL.Excluir(g);
                        Response.Write("<script language='JavaScript'>alert('Galeria excluída com sucesso');location='ListarGalerias.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA AS GALERIAS //
                rptGalerias.DataSource = gDAL.Listar();
                rptGalerias.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarGaleria(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarGaleria.aspx"); }
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