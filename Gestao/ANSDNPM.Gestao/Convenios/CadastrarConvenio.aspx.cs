using System;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Convenios
{
    public partial class CadastrarConvenio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Convenio c = new Convenio();

                c.NMConvenio = Util.formataTexto(txtNome.Text, false);
                c.DSConvenio = Util.formataTexto(txtDescricao.Text, false);
                c.UFConvenio = ddlUF.SelectedValue;

                if (radAtivo_N.Checked)
                { c.BTAtivo = false; }
                else
                { c.BTAtivo = true; }

                ConvenioDAL cDAL = new ConvenioDAL();
                cDAL.Cadastrar(c);

                Response.Write("<script language='JavaScript'>alert('Convênio cadastrado com sucesso');window.parent.location='ListarConvenios.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}