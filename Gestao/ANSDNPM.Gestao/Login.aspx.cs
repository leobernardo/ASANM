using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["log"] == "0")
                {
                    Session["sesIDUsuario"] = null;
                    Session.Abandon();

                    Response.Write("<script language='JavaScript'>alert('Usuário desconectado com sucesso');</script>");
                }
            }
            catch (Exception)
            { throw; }
        }

        protected void Entrar(object sender, EventArgs e)
        {
            try
            {
                String strLogin, strSenha;

                strLogin = txtLogin.Text.Replace("'", "");
                strSenha = txtSenha.Text.Replace("'", "");

                UsuarioDAL usDAL = new UsuarioDAL();

                if (usDAL.Autenticar(strLogin, strSenha))
                { Response.Redirect("Home/Default.aspx"); }
                else
                { Response.Write("<script language='JavaScript'>alert('Login ou senha incorretos');history.go(-1);</script>"); }
            }
            catch (Exception)
            { throw; }
        }
    }
}