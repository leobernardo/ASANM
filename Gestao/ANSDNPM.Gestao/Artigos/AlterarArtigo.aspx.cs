using System;
using System.Web.UI;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Artigos
{
    public partial class AlterarArtigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ArtigoDAL aDAL = new ArtigoDAL();
                    Artigo a = aDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idArt"]));

                    txtTitulo.Text = a.DSTitulo;
                    ckeditor_standard.InnerText = a.DSCorpo;

                    if (a.BTAtivo == true)
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
                ArtigoDAL aDAL = new ArtigoDAL();
                Artigo a = aDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idArt"]));

                a.DSTitulo = Util.formataTexto(txtTitulo.Text, false);
                a.DSCorpo = ckeditor_standard.InnerText;

                if (radAtivo_N.Checked)
                { a.BTAtivo = false; }
                else
                { a.BTAtivo = true; }

                aDAL.Alterar(a);

                Response.Write("<script language='JavaScript'>alert('Artigo alterado com sucesso');window.parent.location='ListarArtigos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}