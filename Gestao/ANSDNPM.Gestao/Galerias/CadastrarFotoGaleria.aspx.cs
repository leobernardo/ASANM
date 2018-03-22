using System;
using System.Configuration;


using ASANM.Dominio;
using ASANM.Integracao;

namespace ASANM.Gestao.Galerias
{
    public partial class CadastrarFotoGaleria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            try
            {
                FotoGaleriaDAL fgDAL = new FotoGaleriaDAL();
                GaleriaDAL gDAL = new GaleriaDAL();

                #region FOTO 1
                if (txtFoto1.HasFile)
                {
                    switch (txtFoto1.FileName.Substring(txtFoto1.FileName.Length - 4))
                    {
                        case ".jpg":

                            FotoGaleria fg_1 = new FotoGaleria();
                            fg_1.Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));
                            fg_1.DSArquivoFoto = "-";
                            
                            fgDAL.Cadastrar(fg_1);

                            FotoGaleria fgUltimo = fgDAL.ObterDadosUltimoCadastrado();

                            string strNome;

                            strNome = fgUltimo.IDFotoGaleria + txtFoto1.FileName.Substring(txtFoto1.FileName.Length - 4);
                            fgUltimo.DSArquivoFoto = strNome;

                            txtFoto1.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Galerias\" + strNome);

                            fgDAL.Alterar(fgUltimo);

                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #region FOTO 2
                if (txtFoto2.HasFile)
                {
                    switch (txtFoto2.FileName.Substring(txtFoto2.FileName.Length - 4))
                    {
                        case ".jpg":

                            FotoGaleria fg_2 = new FotoGaleria();
                            fg_2.Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));
                            fg_2.DSArquivoFoto = "-";

                            fgDAL.Cadastrar(fg_2);

                            FotoGaleria fgUltimo = fgDAL.ObterDadosUltimoCadastrado();

                            string strNome;

                            strNome = fgUltimo.IDFotoGaleria + txtFoto2.FileName.Substring(txtFoto2.FileName.Length - 4);
                            fgUltimo.DSArquivoFoto = strNome;

                            txtFoto2.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Galerias\" + strNome);

                            fgDAL.Alterar(fgUltimo);

                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #region FOTO 3
                if (txtFoto3.HasFile)
                {
                    switch (txtFoto3.FileName.Substring(txtFoto3.FileName.Length - 4))
                    {
                        case ".jpg":

                            FotoGaleria fg_3 = new FotoGaleria();
                            fg_3.Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));
                            fg_3.DSArquivoFoto = "-";

                            fgDAL.Cadastrar(fg_3);

                            FotoGaleria fgUltimo = fgDAL.ObterDadosUltimoCadastrado();

                            string strNome;

                            strNome = fgUltimo.IDFotoGaleria + txtFoto3.FileName.Substring(txtFoto3.FileName.Length - 4);
                            fgUltimo.DSArquivoFoto = strNome;

                            txtFoto3.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Galerias\" + strNome);

                            fgDAL.Alterar(fgUltimo);

                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #region FOTO 4
                if (txtFoto4.HasFile)
                {
                    switch (txtFoto4.FileName.Substring(txtFoto4.FileName.Length - 4))
                    {
                        case ".jpg":

                            FotoGaleria fg_3 = new FotoGaleria();
                            fg_3.Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));
                            fg_3.DSArquivoFoto = "-";

                            fgDAL.Cadastrar(fg_3);

                            FotoGaleria fgUltimo = fgDAL.ObterDadosUltimoCadastrado();

                            string strNome;

                            strNome = fgUltimo.IDFotoGaleria + txtFoto4.FileName.Substring(txtFoto4.FileName.Length - 4);
                            fgUltimo.DSArquivoFoto = strNome;

                            txtFoto4.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Galerias\" + strNome);

                            fgDAL.Alterar(fgUltimo);

                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #region FOTO 5
                if (txtFoto5.HasFile)
                {
                    switch (txtFoto5.FileName.Substring(txtFoto5.FileName.Length - 4))
                    {
                        case ".jpg":

                            FotoGaleria fg_3 = new FotoGaleria();
                            fg_3.Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(Request.QueryString["idGlr"]));
                            fg_3.DSArquivoFoto = "-";

                            fgDAL.Cadastrar(fg_3);

                            FotoGaleria fgUltimo = fgDAL.ObterDadosUltimoCadastrado();

                            string strNome;

                            strNome = fgUltimo.IDFotoGaleria + txtFoto5.FileName.Substring(txtFoto5.FileName.Length - 4);
                            fgUltimo.DSArquivoFoto = strNome;

                            txtFoto5.SaveAs(ConfigurationManager.AppSettings["path"] + @"\Galerias\" + strNome);

                            fgDAL.Alterar(fgUltimo);

                            break;
                        default:
                            break;
                    }
                }
                #endregion

                Response.Write("<script language='JavaScript'>alert('Foto(s) da Galeria cadastrada(s) com sucesso');window.location='FotosGaleria.aspx?idGlr=" + Request.QueryString["idGlr"] + "';</script>");
            }
            catch (Exception)
            { throw; }
        }
    }
}