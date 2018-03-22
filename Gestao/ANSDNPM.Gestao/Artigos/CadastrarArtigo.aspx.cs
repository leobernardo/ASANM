using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Artigos
{
    public partial class CadastrarArtigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Artigo a = new Artigo();

                a.DSTitulo = Util.formataTexto(txtTitulo.Text, false);
                a.DSCorpo = ckeditor_standard.InnerText;

                if (radAtivo_N.Checked)
                { a.BTAtivo = false; }
                else
                { a.BTAtivo = true; }

                ArtigoDAL aDAL = new ArtigoDAL();
                aDAL.Cadastrar(a);

                Response.Write("<script language='JavaScript'>alert('Artigo cadastrado com sucesso');window.parent.location='ListarArtigos.aspx';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}