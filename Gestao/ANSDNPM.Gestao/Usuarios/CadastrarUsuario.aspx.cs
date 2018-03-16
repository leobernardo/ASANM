using System;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Usuarios
{
    public partial class CadastrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Usuario u = new Usuario();

                u.DSNome = Util.formataTexto(txtNome.Text, true);
                u.DSLogin = Util.formataTexto(txtLogin.Text, false);
                u.DSSenha = txtSenha.Text;

                if (radAtivo_N.Checked)
                { u.BTAtivo = false; }
                else
                { u.BTAtivo = true; }

                UsuarioDAL uDAL = new UsuarioDAL();
                uDAL.Cadastrar(u);

                Response.Write("<script language='JavaScript'>alert('Usuário cadastrado com sucesso');window.parent.location='ListarUsuarios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}