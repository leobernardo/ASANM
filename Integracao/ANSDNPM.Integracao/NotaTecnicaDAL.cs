using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data.OleDb;

using ASANM.Dominio;
using ASANM.Interfaces;

namespace ASANM.Integracao
{
    public class NotaTecnicaDAL : IDal
    {
        public NotaTecnica ObterDadosPorId(int _IdNotaTecnica)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    NotaTecnica nt = new NotaTecnica();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDNotaTecnica,NRNotaTecnica,NRAnoNotaTecnica,DSTitulo,DSCorpo,BTAtiva FROM TB_NotaTecnica WHERE IDNotaTecnica = @IDNotaTecnica", objConn);
                    cmd.Parameters.Add("@IDNotaTecnica", OleDbType.Integer).Value = _IdNotaTecnica;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        nt.IDNotaTecnica = Convert.ToInt32(dr["IDNotaTecnica"]);
                        nt.NRNotaTecnica = Convert.ToInt32(dr["NRNotaTecnica"]);
                        nt.NRAnoNotaTecnica = Convert.ToInt32(dr["NRAnoNotaTecnica"]);
                        nt.DSTitulo = dr["DSTitulo"].ToString();
                        nt.DSCorpo = dr["DSCorpo"].ToString();
                        nt.BTAtiva = Convert.ToBoolean(dr["BTAtiva"]);
                    }

                    return nt;
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

                    NotaTecnica nt = (NotaTecnica)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_NotaTecnica SET NRNotaTecnica=?,NRAnoNotaTecnica=?,DSTitulo=?,DSCorpo=?,BTAtiva=? WHERE IDNotaTecnica=?", objConn);
                    cmd.Parameters.Add("@NRNotaTecnica", OleDbType.Integer).Value = nt.NRNotaTecnica;
                    cmd.Parameters.Add("@NRAnoNotaTecnica", OleDbType.Integer).Value = nt.NRAnoNotaTecnica;
                    cmd.Parameters.Add("@DSTitulo", OleDbType.VarChar, 100).Value = nt.DSTitulo;
                    cmd.Parameters.Add("@DSCorpo", OleDbType.LongVarChar).Value = nt.DSCorpo;
                    cmd.Parameters.Add("@BTAtiva", OleDbType.Boolean).Value = nt.BTAtiva;
                    cmd.Parameters.Add("@IDNotaTecnica", OleDbType.Integer).Value = nt.IDNotaTecnica;
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

                    NotaTecnica nt = (NotaTecnica)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_NotaTecnica(NRNotaTecnica,NRAnoNotaTecnica,DSTitulo,DSCorpo,BTAtiva) VALUES(@NRNotaTecnica,@NRAnoNotaTecnica,@DSTitulo,@DSCorpo,@BTAtiva)", objConn);
                    cmd.Parameters.Add("@NRNotaTecnica", OleDbType.Integer).Value = nt.NRNotaTecnica;
                    cmd.Parameters.Add("@NRAnoNotaTecnica", OleDbType.Integer).Value = nt.NRAnoNotaTecnica;
                    cmd.Parameters.Add("@DSTitulo", OleDbType.VarChar, 100).Value = nt.DSTitulo;
                    cmd.Parameters.Add("@DSCorpo", OleDbType.LongVarChar).Value = nt.DSCorpo;
                    cmd.Parameters.Add("@BTAtiva", OleDbType.Boolean).Value = nt.BTAtiva;
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

                    NotaTecnica nt = (NotaTecnica)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_NotaTecnica WHERE IDNotaTecnica = @IDNotaTecnica", objConn);
                    cmd.Parameters.Add("@IDNotaTecnica", OleDbType.Integer).Value = nt.IDNotaTecnica;
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

                    List<NotaTecnica> lst = new List<NotaTecnica>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDNotaTecnica,NRNotaTecnica,NRAnoNotaTecnica,DSTitulo,DSCorpo,BTAtiva FROM TB_NotaTecnica ORDER BY NRAnoNotaTecnica DESC, NRNotaTecnica DESC", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new NotaTecnica()
                                {
                                    IDNotaTecnica = Convert.ToInt32(dr["IDNotaTecnica"]),
                                    NRNotaTecnica = Convert.ToInt32(dr["NRNotaTecnica"]),
                                    NRAnoNotaTecnica = Convert.ToInt32(dr["NRAnoNotaTecnica"]),
                                    DSTitulo = dr["DSTitulo"].ToString(),
                                    DSCorpo = dr["DSCorpo"].ToString(),
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
