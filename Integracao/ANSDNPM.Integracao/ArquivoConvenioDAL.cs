using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data.OleDb;

using ASANM.Dominio;
using ASANM.Interfaces;

namespace ASANM.Integracao
{
    public class ArquivoConvenioDAL : IDal
    {
        public ArquivoConvenio ObterDadosPorId(int _IdArquivoConvenio)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivoConvenio ac = new ArquivoConvenio();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDArquivoConvenio,IDConvenio,NMArquivo,DSArquivo FROM TB_ArquivoConvenio WHERE IDArquivoConvenio = @IDArquivoConvenio", objConn);
                    cmd.Parameters.Add("@IDArquivoConvenio", OleDbType.Integer).Value = _IdArquivoConvenio;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    ConvenioDAL cDAL = new ConvenioDAL();

                    if (dr.Read())
                    {
                        ac.IDArquivoConvenio = Convert.ToInt32(dr["IDArquivoConvenio"]);
                        ac.Convenio = cDAL.ObterDadosPorId(Convert.ToInt32(dr["IDConvenio"]));
                        ac.NMArquivo = dr["NMArquivo"].ToString();
                        ac.DSArquivo = dr["DSArquivo"].ToString();
                    }

                    return ac;
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

        public ArquivoConvenio ObterDadosUltimoCadastrado()
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivoConvenio ac = new ArquivoConvenio();

                    OleDbCommand cmd1 = new OleDbCommand("SELECT MAX(IDArquivoConvenio) AS IDArquivoConvenio FROM TB_ArquivoConvenio", objConn);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        OleDbCommand cmd2 = new OleDbCommand("SELECT IDArquivoConvenio,IDConvenio,NMArquivo,DSArquivo FROM TB_ArquivoConvenio WHERE IDArquivoConvenio = " + dr1["IDArquivoConvenio"], objConn);
                        OleDbDataReader dr2 = cmd2.ExecuteReader();

                        ConvenioDAL cDAL = new ConvenioDAL();

                        if (dr2.Read())
                        {
                            ac.IDArquivoConvenio = Convert.ToInt32(dr2["IDArquivoConvenio"]);
                            ac.Convenio = cDAL.ObterDadosPorId(Convert.ToInt32(dr2["IDConvenio"]));
                            ac.NMArquivo = dr2["NMArquivo"].ToString();
                            ac.DSArquivo = dr2["DSArquivo"].ToString();
                        }
                    }

                    return ac;
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

                    ArquivoConvenio ac = (ArquivoConvenio)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_ArquivoConvenio SET IDConvenio=?,NMArquivo=?,DSArquivo=? WHERE IDArquivoConvenio=?", objConn);
                    cmd.Parameters.Add("@IDConvenio", OleDbType.Integer).Value = ac.Convenio.IDConvenio;
                    cmd.Parameters.Add("@NMArquivo", OleDbType.VarChar, 100).Value = ac.NMArquivo;
                    cmd.Parameters.Add("@DSArquivo", OleDbType.VarChar, 100).Value = ac.DSArquivo;
                    cmd.Parameters.Add("@IDArquivoConvenio", OleDbType.Integer).Value = ac.IDArquivoConvenio;
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
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    ArquivoConvenio ac = (ArquivoConvenio)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_ArquivoConvenio(IDConvenio,NMArquivo,DSArquivo) VALUES(@IDConvenio,@NMArquivo,@DSArquivo)", objConn);
                    cmd.Parameters.Add("@IDConvenio", OleDbType.Integer).Value = ac.Convenio.IDConvenio;
                    cmd.Parameters.Add("@NMArquivo", OleDbType.VarChar, 100).Value = ac.NMArquivo;
                    cmd.Parameters.Add("@DSArquivo", OleDbType.VarChar, 100).Value = ac.DSArquivo;
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

                    ArquivoConvenio ac = (ArquivoConvenio)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_ArquivoConvenio WHERE IDArquivoConvenio = @IDArquivoConvenio", objConn);
                    cmd.Parameters.Add("@IDArquivoConvenio", OleDbType.Integer).Value = ac.IDArquivoConvenio;
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

                    List<ArquivoConvenio> lst = new List<ArquivoConvenio>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDArquivoConvenio,IDConvenio,NMArquivo,DSArquivo FROM TB_ArquivoConvenio ORDER BY DSArquivo", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    ConvenioDAL cDAL = new ConvenioDAL();

                    while (dr.Read())
                    {
                        lst.Add(
                                new ArquivoConvenio()
                                {
                                    IDArquivoConvenio = Convert.ToInt32(dr["IDArquivoConvenio"]),
                                    Convenio = cDAL.ObterDadosPorId(Convert.ToInt32(dr["IDConvenio"])),
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
