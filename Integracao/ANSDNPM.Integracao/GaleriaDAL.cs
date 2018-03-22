using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data.OleDb;

using ASANM.Dominio;
using ASANM.Interfaces;

namespace ASANM.Integracao
{
    public class GaleriaDAL : IDal
    {
        public Galeria ObterDadosPorId(int _IdGaleria)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Galeria g = new Galeria();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDGaleria,DSGaleria,BTAtiva FROM TB_Galeria WHERE IDGaleria = @IDGaleria", objConn);
                    cmd.Parameters.Add("@IDGaleria", OleDbType.Integer).Value = _IdGaleria;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        g.IDGaleria = Convert.ToInt32(dr["IDGaleria"]);
                        g.DSGaleria = dr["DSGaleria"].ToString();
                        g.BTAtiva = Convert.ToBoolean(dr["BTAtiva"]);
                    }

                    return g;
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
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Galeria g = (Galeria)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_Galeria SET DSGaleria=?,BTAtiva=? WHERE IDGaleria=?", objConn);
                    cmd.Parameters.Add("@DSGaleria", OleDbType.VarChar, 100).Value = g.DSGaleria;
                    cmd.Parameters.Add("@BTAtiva", OleDbType.Boolean).Value = g.BTAtiva;
                    cmd.Parameters.Add("@IDGaleria", OleDbType.Integer).Value = g.IDGaleria;
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
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Galeria g = (Galeria)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_Galeria(DSGaleria,BTAtiva) VALUES(@DSGaleria,@BTAtiva)", objConn);
                    cmd.Parameters.Add("@DSGaleria", OleDbType.VarChar, 100).Value = g.DSGaleria;
                    cmd.Parameters.Add("@BTAtiva", OleDbType.Boolean).Value = g.BTAtiva;
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
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Galeria g = (Galeria)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_Galeria WHERE IDGaleria = @IDGaleria", objConn);
                    cmd.Parameters.Add("@IDGaleria", OleDbType.Integer).Value = g.IDGaleria;
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
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    List<Galeria> lst = new List<Galeria>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDGaleria,DSGaleria,BTAtiva FROM TB_Galeria", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Galeria()
                                {
                                    IDGaleria = Convert.ToInt32(dr["IDGaleria"]),
                                    DSGaleria = dr["DSGaleria"].ToString(),
                                    BTAtiva = Convert.ToBoolean(dr["BTAtiva"])
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
