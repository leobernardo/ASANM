using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data.OleDb;

using ANSDNPM.Dominio;
using ANSDNPM.Interfaces;

namespace ANSDNPM.Integracao
{
    public class FotoGaleriaDAL : IDal
    {
        public FotoGaleria ObterDadosPorId(int _IdFotoGaleria)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    FotoGaleria fg = new FotoGaleria();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDFotoGaleria,IDGaleria,DSArquivoFoto FROM TB_FotoGaleria WHERE IDFotoGaleria = @IDFotoGaleria", objConn);
                    cmd.Parameters.Add("@IDFotoGaleria", OleDbType.Integer).Value = _IdFotoGaleria;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    GaleriaDAL gDAL = new GaleriaDAL();

                    if (dr.Read())
                    {
                        fg.IDFotoGaleria = Convert.ToInt32(dr["IDFotoGaleria"]);
                        fg.Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(dr["IDGaleria"]));
                        fg.DSArquivoFoto = dr["DSArquivoFoto"].ToString();
                    }

                    return fg;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public FotoGaleria ObterDadosUltimoCadastrado()
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    FotoGaleria fg = new FotoGaleria();

                    OleDbCommand cmd1 = new OleDbCommand("SELECT MAX(IDFotoGaleria) AS IDFotoGaleria FROM TB_FotoGaleria", objConn);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        OleDbCommand cmd2 = new OleDbCommand("SELECT IDFotoGaleria,IDGaleria,DSArquivoFoto FROM TB_FotoGaleria WHERE IDFotoGaleria = " + dr1["IDFotoGaleria"], objConn);
                        OleDbDataReader dr2 = cmd2.ExecuteReader();

                        GaleriaDAL gDAL = new GaleriaDAL();

                        if (dr2.Read())
                        {
                            fg.IDFotoGaleria = Convert.ToInt32(dr2["IDFotoGaleria"]);
                            fg.Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(dr2["IDGaleria"]));
                            fg.DSArquivoFoto = dr2["DSArquivoFoto"].ToString();
                        }
                    }

                    return fg;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public void Alterar(object obj)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    FotoGaleria fg = (FotoGaleria)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_FotoGaleria SET IDGaleria=?,DSArquivoFoto=? WHERE IDFotoGaleria=?", objConn);
                    cmd.Parameters.Add("@IDGaleria", OleDbType.Integer).Value = fg.Galeria.IDGaleria;
                    cmd.Parameters.Add("@DSArquivoFoto", OleDbType.VarChar, 10).Value = fg.DSArquivoFoto;
                    cmd.Parameters.Add("@IDFotoGaleria", OleDbType.Integer).Value = fg.IDFotoGaleria;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public void Cadastrar(object obj)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    FotoGaleria fg = (FotoGaleria)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_FotoGaleria(IDGaleria,DSArquivoFoto) VALUES(@IDGaleria,@DSArquivoFoto)", objConn);
                    cmd.Parameters.Add("@IDGaleria", OleDbType.Integer).Value = fg.Galeria.IDGaleria;
                    cmd.Parameters.Add("@DSArquivoFoto", OleDbType.VarChar, 10).Value = fg.DSArquivoFoto;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public void Excluir(object obj)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    FotoGaleria fg = (FotoGaleria)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_FotoGaleria WHERE IDFotoGaleria = @IDFotoGaleria", objConn);
                    cmd.Parameters.Add("@IDFotoGaleria", OleDbType.Integer).Value = fg.IDFotoGaleria;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }

        public IList Listar()
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    List<FotoGaleria> lst = new List<FotoGaleria>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDFotoGaleria,IDGaleria,DSArquivoFoto FROM TB_FotoGaleria", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    GaleriaDAL gDAL = new GaleriaDAL();

                    while (dr.Read())
                    {
                        lst.Add(
                                new FotoGaleria()
                                {
                                    IDFotoGaleria = Convert.ToInt32(dr["IDFotoGaleria"]),
                                    Galeria = gDAL.ObterDadosPorId(Convert.ToInt32(dr["IDGaleria"])),
                                    DSArquivoFoto = dr["DSArquivoFoto"].ToString()
                                }
                        );
                    }

                    return lst;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }
    }
}
