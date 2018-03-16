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
    public class ArtigoDAL : IDal
    {
        public Artigo ObterDadosPorId(int _IdArtigo)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Artigo a = new Artigo();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDArtigo,DSTitulo,DSCorpo,BTAtivo FROM TB_Artigo WHERE IDArtigo = @IDArtigo", objConn);
                    cmd.Parameters.Add("@IDArtigo", OleDbType.Integer).Value = _IdArtigo;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        a.IDArtigo = Convert.ToInt32(dr["IDArtigo"]);
                        a.DSTitulo = dr["DSTitulo"].ToString();
                        a.DSCorpo = dr["DSCorpo"].ToString();
                        a.BTAtivo = Convert.ToBoolean(dr["BTAtivo"]);
                    }

                    return a;
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

                    Artigo a = (Artigo)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_Artigo SET DSTitulo=?,DSCorpo=?,BTAtivo=? WHERE IDArtigo=?", objConn);
                    cmd.Parameters.Add("@DSTitulo", OleDbType.VarChar, 100).Value = a.DSTitulo;
                    cmd.Parameters.Add("@DSCorpo", OleDbType.LongVarChar).Value = a.DSCorpo;
                    cmd.Parameters.Add("@BTAtivo", OleDbType.Boolean).Value = a.BTAtivo;
                    cmd.Parameters.Add("@IDArtigo", OleDbType.Integer).Value = a.IDArtigo;
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

                    Artigo a = (Artigo)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_Artigo(DSTitulo,DSCorpo,BTAtivo) VALUES(@DSTitulo,@DSCorpo,@BTAtivo)", objConn);
                    cmd.Parameters.Add("@DSTitulo", OleDbType.VarChar, 100).Value = a.DSTitulo;
                    cmd.Parameters.Add("@DSCorpo", OleDbType.LongVarChar).Value = a.DSCorpo;
                    cmd.Parameters.Add("@BTAtivo", OleDbType.Boolean).Value = a.BTAtivo;
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

                    Artigo a = (Artigo)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_Artigo WHERE IDArtigo = @IDArtigo", objConn);
                    cmd.Parameters.Add("@IDArtigo", OleDbType.Integer).Value = a.IDArtigo;
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

                    List<Artigo> lst = new List<Artigo>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDArtigo,DSTitulo,DSCorpo,BTAtivo FROM TB_Artigo", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Artigo()
                                {
                                    IDArtigo = Convert.ToInt32(dr["IDArtigo"]),
                                    DSTitulo = dr["DSTitulo"].ToString(),
                                    DSCorpo = dr["DSCorpo"].ToString(),
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
