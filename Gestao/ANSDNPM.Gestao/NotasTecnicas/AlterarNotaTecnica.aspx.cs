using System;
using System.Web.UI;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.NotasTecnicas
{
    public partial class AlterarNotaTecnica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();
                    NotaTecnica nt = ntDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtt"]));

                    ddlAno.SelectedValue = nt.NRAnoNotaTecnica.ToString();
                    txtNumero.Text = nt.NRNotaTecnica.ToString();
                    txtTitulo.Text = nt.DSTitulo;
                    ckeditor_standard.InnerText = nt.DSCorpo;

                    if (nt.BTAtiva == true)
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
                NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();
                NotaTecnica nt = ntDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idNtt"]));

                nt.NRAnoNotaTecnica = Convert.ToInt32(ddlAno.SelectedValue);
                nt.NRNotaTecnica = Convert.ToInt32(txtNumero.Text);
                nt.DSTitulo = Util.formataTexto(txtTitulo.Text, false);
                nt.DSCorpo = ckeditor_standard.InnerText;

                if (radAtiva_N.Checked)
                { nt.BTAtiva = false; }
                else
                { nt.BTAtiva = true; }

                ntDAL.Alterar(nt);

                Response.Write("<script language='JavaScript'>alert('Nota Técnica alterada com sucesso');window.parent.location='ListarNotasTecnicas.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}