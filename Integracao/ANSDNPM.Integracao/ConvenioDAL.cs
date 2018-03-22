using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data.OleDb;

using ASANM.Dominio;
using ASANM.Interfaces;

namespace ASANM.Integracao
{
    public class ConvenioDAL : IDal
    {
        public Convenio ObterDadosPorId(int _IdConvenio)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Convenio c = new Convenio();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDConvenio,NMConvenio,DSConvenio,UFConvenio,BTAtivo FROM TB_Convenio WHERE IDConvenio = @IDConvenio", objConn);
                    cmd.Parameters.Add("@IDConvenio", OleDbType.Integer).Value = _IdConvenio;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        c.IDConvenio = Convert.ToInt32(dr["IDConvenio"]);
                        c.NMConvenio = dr["NMConvenio"].ToString();
                        c.DSConvenio = dr["DSConvenio"].ToString();
                        c.UFConvenio = dr["UFConvenio"].ToString();
                        c.BTAtivo = Convert.ToBoolean(dr["BTAtivo"]);
                    }

                    return c;
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

                    Convenio c = (Convenio)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_Convenio SET NMConvenio=?,DSConvenio=?,UFConvenio=?,BTAtivo=? WHERE IDConvenio=?", objConn);
                    cmd.Parameters.Add("@NMConvenio", OleDbType.VarChar, 100).Value = c.NMConvenio;
                    cmd.Parameters.Add("@DSConvenio", OleDbType.LongVarChar).Value = c.DSConvenio;
                    cmd.Parameters.Add("@UFConvenio", OleDbType.VarChar, 2).Value = c.UFConvenio;
                    cmd.Parameters.Add("@BTAtivo", OleDbType.Boolean).Value = c.BTAtivo;
                    cmd.Parameters.Add("@IDConvenio", OleDbType.Integer).Value = c.IDConvenio;
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

                    Convenio c = (Convenio)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_Convenio(NMConvenio,DSConvenio,UFConvenio,BTAtivo) VALUES(@NMConvenio,@DSConvenio,@UFConvenio,@BTAtivo)", objConn);
                    cmd.Parameters.Add("@NMConvenio", OleDbType.VarChar, 100).Value = c.NMConvenio;
                    cmd.Parameters.Add("@DSConvenio", OleDbType.LongVarChar).Value = c.DSConvenio;
                    cmd.Parameters.Add("@UFConvenio", OleDbType.VarChar, 2).Value = c.UFConvenio;
                    cmd.Parameters.Add("@BTAtivo", OleDbType.Boolean).Value = c.BTAtivo;
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

                    Convenio c = (Convenio)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_Convenio WHERE IDConvenio = @IDConvenio", objConn);
                    cmd.Parameters.Add("@IDConvenio", OleDbType.Integer).Value = c.IDConvenio;
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

                    List<Convenio> lst = new List<Convenio>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDConvenio,NMConvenio,DSConvenio,UFConvenio,BTAtivo FROM TB_Convenio", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Convenio()
                                {
                                    IDConvenio = Convert.ToInt32(dr["IDConvenio"]),
                                    NMConvenio = dr["NMConvenio"].ToString(),
                                    DSConvenio = dr["DSConvenio"].ToString(),
                                    UFConvenio = dr["UFConvenio"].ToString(),
                                    BTAtivo = Convert.ToBoolean(dr["BTAtivo"])
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
