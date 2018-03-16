using System;

using ANSDNPM.Dominio;
using ANSDNPM.Integracao;

namespace ANSDNPM.Gestao.NotasTecnicas
{
    public partial class CadastrarNotaTecnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                NotaTecnica nt = new NotaTecnica();

                nt.NRAnoNotaTecnica = Convert.ToInt32(ddlAno.SelectedValue);
                nt.NRNotaTecnica = Convert.ToInt32(txtNumero.Text);
                nt.DSTitulo = Util.formataTexto(txtTitulo.Text, false);
                nt.DSCorpo = ckeditor_standard.InnerText;

                if (radAtiva_N.Checked)
                { nt.BTAtiva = false; }
                else
                { nt.BTAtiva = true; }

                NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();
                ntDAL.Cadastrar(nt);

                Response.Write("<script language='JavaScript'>alert('Nota Técnica cadastrada com sucesso');window.parent.location='ListarNotasTecnicas.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}