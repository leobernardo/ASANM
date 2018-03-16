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
    public class NoticiaDAL : IDal
    {
        public Noticia ObterDadosPorId(int _IdNoticia)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Noticia n = new Noticia();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDNoticia,DSTitulo,DSCorpo,DSArquivoImagem,BTAtiva FROM TB_Noticia WHERE IDNoticia = @IDNoticia", objConn);
                    cmd.Parameters.Add("@IDNoticia", OleDbType.Integer).Value = _IdNoticia;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        n.IDNoticia = Convert.ToInt32(dr["IDNoticia"]);
                        n.DSTitulo = dr["DSTitulo"].ToString();
                        n.DSCorpo = dr["DSCorpo"].ToString();
                        n.DSArquivoImagem = dr["DSArquivoImagem"].ToString();
                        n.BTAtiva = Convert.ToBoolean(dr["BTAtiva"]);
                    }

                    return n;
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

        public Noticia ObterDadosUltimoCadastrado()
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBAnsdnpm"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Noticia n = new Noticia();

                    OleDbCommand cmd1 = new OleDbCommand("SELECT MAX(IDNoticia) AS IDNoticia FROM TB_Noticia", objConn);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();

                    if (dr1.Read())
                    {
                        OleDbCommand cmd2 = new OleDbCommand("SELECT IDNoticia,DSTitulo,DSCorpo,DSArquivoImagem,BTAtiva FROM TB_Noticia WHERE IDNoticia = " + dr1["IDNoticia"], objConn);
                        OleDbDataReader dr2 = cmd2.ExecuteReader();

                        GaleriaDAL gDAL = new GaleriaDAL();

                        if (dr2.Read())
                        {
                            n.IDNoticia = Convert.ToInt32(dr2["IDNoticia"]);
                            n.DSTitulo = dr2["DSTitulo"].ToString();
                            n.DSCorpo = dr2["DSCorpo"].ToString();
                            n.DSArquivoImagem = dr2["DSArquivoImagem"].ToString();
                            n.BTAtiva = Convert.ToBoolean(dr2["BTAtiva"]);
                        }
                    }

                    return n;
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

                    Noticia n = (Noticia)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_Noticia SET DSTitulo=?,DSCorpo=?,DSArquivoImagem=?,BTAtiva=? WHERE IDNoticia=?", objConn);
                    cmd.Parameters.Add("@DSTitulo", OleDbType.VarChar, 100).Value = n.DSTitulo;
                    cmd.Parameters.Add("@DSCorpo", OleDbType.LongVarChar).Value = n.DSCorpo;
                    cmd.Parameters.Add("@DSArquivoImagem", OleDbType.VarChar, 10).Value = n.DSArquivoImagem;
                    cmd.Parameters.Add("@BTAtiva", OleDbType.Boolean).Value = n.BTAtiva;
                    cmd.Parameters.Add("@IDNoticia", OleDbType.Integer).Value = n.IDNoticia;
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

                    Noticia n = (Noticia)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_Noticia(DSTitulo,DSCorpo,DSArquivoImagem,BTAtiva) VALUES(@DSTitulo,@DSCorpo,@DSArquivoImagem,@BTAtiva)", objConn);
                    cmd.Parameters.Add("@DSTitulo", OleDbType.VarChar, 100).Value = n.DSTitulo;
                    cmd.Parameters.Add("@DSCorpo", OleDbType.LongVarChar).Value = n.DSCorpo;
                    cmd.Parameters.Add("@DSArquivoImagem", OleDbType.VarChar, 10).Value = n.DSArquivoImagem;
                    cmd.Parameters.Add("@BTAtiva", OleDbType.Boolean).Value = n.BTAtiva;
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

                    Noticia n = (Noticia)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_Noticia WHERE IDNoticia = @IDNoticia", objConn);
                    cmd.Parameters.Add("@IDNoticia", OleDbType.Integer).Value = n.IDNoticia;
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

                    List<Noticia> lst = new List<Noticia>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDNoticia,DSTitulo,DSCorpo,DSArquivoImagem,BTAtiva FROM TB_Noticia", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Noticia()
                                {
                                    IDNoticia = Convert.ToInt32(dr["IDNoticia"]),
                                    DSTitulo = dr["DSTitulo"].ToString(),
                                    DSCorpo = dr["DSCorpo"].ToString(),
                                    DSArquivoImagem = dr["DSArquivoImagem"].ToString(),
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
