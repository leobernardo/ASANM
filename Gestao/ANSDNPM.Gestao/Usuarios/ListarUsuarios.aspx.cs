using System;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Usuarios
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();

                switch (Request.QueryString["act"])
                {
                    case "exc":
                        Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idUsr"]));
                        uDAL.Excluir(u);
                        Response.Write("<script language='JavaScript'>alert('Usuário excluído com sucesso');location='ListarUsuarios.aspx';</script>");
                        break;
                    default:
                        break;
                }

                // LISTA OS USUÁRIOS //
                rptUsuarios.DataSource = uDAL.Listar();
                rptUsuarios.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }

        protected void CadastrarUsuario(object sender, EventArgs e)
        {
            try
            { Response.Redirect("CadastrarUsuario.aspx"); }
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