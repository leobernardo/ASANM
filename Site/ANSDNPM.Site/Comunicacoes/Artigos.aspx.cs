﻿using System;
using System.Linq;

using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Site.Comunicacoes
{
    public partial class Artigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // LISTA OS ARTIGOS //
                ArtigoDAL aDAL = new ArtigoDAL();
                rptArtigos.DataSource = aDAL.Listar().Cast<Artigo>().Where(a => a.BTAtivo == true);
                rptArtigos.DataBind();
                // FIM //
            }
            catch (Exception)
            { throw; }
        }
    }
}