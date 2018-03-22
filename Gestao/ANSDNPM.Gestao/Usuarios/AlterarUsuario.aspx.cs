using System;
using System.Web.UI;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Usuarios
{
    public partial class AlterarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    UsuarioDAL uDAL = new UsuarioDAL();
                    Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idUsr"]));

                    txtNome.Text = u.DSNome;
                    txtLogin.Text = u.DSLogin;

                    if (u.BTAtivo == true)
                    {
                        radAtivo_N.Checked = false;
                        radAtivo_S.Checked = true;
                    }
                    else
                    {
                        radAtivo_N.Checked = true;
                        radAtivo_S.Checked = false;
                    }
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Alterar(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAL uDAL = new UsuarioDAL();
                Usuario u = uDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idUsr"]));

                u.DSNome = Util.formataTexto(txtNome.Text, true);
                u.DSLogin = Util.formataTexto(txtLogin.Text, false);

                if (radAtivo_N.Checked)
                { u.BTAtivo = false; }
                else
                { u.BTAtivo = true; }

                uDAL.Alterar(u);

                Response.Write("<script language='JavaScript'>alert('Usuário alterado com sucesso');window.parent.location='ListarUsuarios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}