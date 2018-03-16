using System;
using System.Web.UI;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.Convenios
{
    public partial class AlterarConvenio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ConvenioDAL cDAL = new ConvenioDAL();
                    Convenio c = cDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idCnv"]));

                    txtNome.Text = c.NMConvenio;
                    txtDescricao.Text = c.DSConvenio;
                    ddlUF.SelectedValue = c.UFConvenio;

                    if (c.BTAtivo == true)
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
                ConvenioDAL cDAL = new ConvenioDAL();
                Convenio c = cDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idCnv"]));

                c.NMConvenio = Util.formataTexto(txtNome.Text, false);
                c.DSConvenio = Util.formataTexto(txtDescricao.Text, false);
                c.UFConvenio = ddlUF.SelectedValue;

                if (radAtivo_N.Checked)
                { c.BTAtivo = false; }
                else
                { c.BTAtivo = true; }

                cDAL.Alterar(c);

                Response.Write("<script language='JavaScript'>alert('Convênio alterado com sucesso');window.parent.location='ListarConvenios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}