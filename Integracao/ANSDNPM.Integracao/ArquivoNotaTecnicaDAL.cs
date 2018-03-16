using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data.OleDb;
using System.Web;

using ANSDNPM.Dominio;
using ANSDNPM.Interfaces;

namespace ANSDNPM.Integracao
{
    public class ArquivoNotaTecnicaDAL : IDal
    {
        public ArquivoNotaTecnica ObterDadosPorId(int _IdArquivoNotaTecnica)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivoNotaTecnica ant = new ArquivoNotaTecnica();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDArquivoNotaTecnica,IDNotaTecnica,NMArquivo,DSArquivo FROM TB_ArquivoNotaTecnica WHERE IDArquivoNotaTecnica = @IDArquivoNotaTecnica", objConn);
                    cmd.Parameters.Add("@IDArquivoNotaTecnica", OleDbType.Integer).Value = _IdArquivoNotaTecnica;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();

                    if (dr.Read())
                    {
                        ant.IDArquivoNotaTecnica = Convert.ToInt32(dr["IDArquivoNotaTecnica"]);
                        ant.NotaTecnica = ntDAL.ObterDadosPorId(Convert.ToInt32(dr["IDNotaTecnica"]));
                        ant.NMArquivo = dr["NMArquivo"].ToString();
                        ant.DSArquivo = dr["DSArquivo"].ToString();
                    }

                    return ant;
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

        public ArquivoNotaTecnica ObterDadosUltimoCadastrado()
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivoNotaTecnica ant = new ArquivoNotaTecnica();

                    OleDbCommand cmd1 = new OleDbCommand("SELECT MAX(IDArquivoNotaTecnica) AS IDArquivoNotaTecnica FROM TB_ArquivoNotaTecnica", objConn);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        OleDbCommand cmd2 = new OleDbCommand("SELECT IDArquivoNotaTecnica,IDNotaTecnica,NMArquivo,DSArquivo FROM TB_ArquivoNotaTecnica WHERE IDArquivoNotaTecnica = " + dr1["IDArquivoNotaTecnica"], objConn);
                        OleDbDataReader dr2 = cmd2.ExecuteReader();

                        NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();

                        if (dr2.Read())
                        {
                            ant.IDArquivoNotaTecnica = Convert.ToInt32(dr2["IDArquivoNotaTecnica"]);
                            ant.NotaTecnica = ntDAL.ObterDadosPorId(Convert.ToInt32(dr2["IDNotaTecnica"]));
                            ant.NMArquivo = dr2["NMArquivo"].ToString();
                            ant.DSArquivo = dr2["DSArquivo"].ToString();
                        }
                    }

                    return ant;
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

                    ArquivoNotaTecnica ant = (ArquivoNotaTecnica)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_ArquivoNotaTecnica SET IDNotaTecnica=?,NMArquivo=?,DSArquivo=? WHERE IDArquivoNotaTecnica=?", objConn);
                    cmd.Parameters.Add("@IDNotaTecnica", OleDbType.Integer).Value = ant.NotaTecnica.IDNotaTecnica;
                    cmd.Parameters.Add("@NMArquivo", OleDbType.VarChar, 100).Value = ant.NMArquivo;
                    cmd.Parameters.Add("@DSArquivo", OleDbType.VarChar, 100).Value = ant.DSArquivo;
                    cmd.Parameters.Add("@IDArquivoNotaTecnica", OleDbType.Integer).Value = ant.IDArquivoNotaTecnica;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                { throw; }
                finally
                { objConn.Close(); }
            }
        }

        public void Cadastrar(object obj)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivoNotaTecnica ant = (ArquivoNotaTecnica)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_ArquivoNotaTecnica(IDNotaTecnica,NMArquivo,DSArquivo) VALUES(@IDNotaTecnica,@NMArquivo,@DSArquivo)", objConn);
                    cmd.Parameters.Add("@IDNotaTecnica", OleDbType.Integer).Value = ant.NotaTecnica.IDNotaTecnica;
                    cmd.Parameters.Add("@NMArquivo", OleDbType.VarChar, 100).Value = ant.NMArquivo;
                    cmd.Parameters.Add("@DSArquivo", OleDbType.VarChar, 100).Value = ant.DSArquivo;
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

                    ArquivoNotaTecnica ant = (ArquivoNotaTecnica)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_ArquivoNotaTecnica WHERE IDArquivoNotaTecnica = @IDArquivoNotaTecnica", objConn);
                    cmd.Parameters.Add("@IDArquivoNotaTecnica", OleDbType.Integer).Value = ant.IDArquivoNotaTecnica;
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

                    List<ArquivoNotaTecnica> lst = new List<ArquivoNotaTecnica>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDArquivoNotaTecnica,IDNotaTecnica,NMArquivo,DSArquivo FROM TB_ArquivoNotaTecnica ORDER BY DSArquivo", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    NotaTecnicaDAL ntDAL = new NotaTecnicaDAL();

                    while (dr.Read())
                    {
                        lst.Add(
                                new ArquivoNotaTecnica()
                                {
                                    IDArquivoNotaTecnica = Convert.ToInt32(dr["IDArquivoNotaTecnica"]),
                                    NotaTecnica = ntDAL.ObterDadosPorId(Convert.ToInt32(dr["IDNotaTecnica"])),
                                    NMArquivo = dr["NMArquivo"].ToString(),
                                    DSArquivo = dr["DSArquivo"].ToString()
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
