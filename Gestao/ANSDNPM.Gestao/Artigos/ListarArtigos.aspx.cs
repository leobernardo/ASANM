using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Artigos
{
    public partial class ListarArtigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArtigoDAL aDAL = new ArtigoDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Artigo a = aDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idArt"]));
                        aDAL.Excluir(a);
                        Response.Write("<script language='JavaScript'>alert('Artigo excluído com sucesso');location='ListarArtigos.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA AS NOTAS TÉCNICAS //
                rptArtigos.DataSource = aDAL.Listar();
                rptArtigos.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarArtigo(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarArtigo.aspx"); }
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