using System;
using System.Web.UI;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Usuarios
{
    public partial class AlterarSenhaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idUsr"]));

                u.DSSenha = txtNovaSenha.Text;

                uDAL.Alterar(u);

                Response.Write("<script language='JavaScript'>alert('Senha do Usuário alterada com sucesso');window.parent.location='ListarUsuarios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}