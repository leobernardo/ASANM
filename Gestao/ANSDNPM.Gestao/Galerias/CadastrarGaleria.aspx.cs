using System;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Galerias
{
    public partial class CadastrarGaleria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Galeria g = new Galeria();

                g.DSGaleria = Util.formataTexto(txtDescricao.Text, false);

                if (radAtiva_N.Checked)
                { g.BTAtiva = false; }
                else
                { g.BTAtiva = true; }

                GaleriaDAL gDAL = new GaleriaDAL();
                gDAL.Cadastrar(g);

                Response.Write("<script language='JavaScript'>alert('Galeria cadastrada com sucesso');window.parent.location='ListarGalerias.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}