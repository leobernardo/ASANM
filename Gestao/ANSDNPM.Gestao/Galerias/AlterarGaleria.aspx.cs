using System;
using System.Web.UI;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Galerias
{
    public partial class AlterarGaleria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    GaleriaDAL gDAL = new GaleriaDAL();
                    Galeria g = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));

                    txtDescricao.Text = g.DSGaleria;

                    if (g.BTAtiva == true)
                    {
                        radAtiva_N.Checked = false;
                        radAtiva_S.Checked = true;
                    }
                    else
                    {
                        radAtiva_N.Checked = true;
                        radAtiva_S.Checked = false;
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
                GaleriaDAL gDAL = new GaleriaDAL();
                Galeria g = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));

                g.DSGaleria = Util.formataTexto(txtDescricao.Text, false);

                if (radAtiva_N.Checked)
                { g.BTAtiva = false; }
                else
                { g.BTAtiva = true; }

                gDAL.Alterar(g);

                Response.Write("<script language='JavaScript'>alert('Galeria alterada com sucesso');window.parent.location='ListarGalerias.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}