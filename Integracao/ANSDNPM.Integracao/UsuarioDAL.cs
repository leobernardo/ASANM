using System;
using System.Collections;
using System.Collections.Generic;

using System.Configuration;
using System.Data.OleDb;
using System.Web;

using ASANM.Dominio;
using ASANM.Interfaces;

namespace ASANM.Integracao
{
    public class UsuarioDAL : IDal
    {
        public Usuario ObterDadosPorId(int _IdUsuario)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Usuario u = new Usuario();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDUsuario,DSNome,DSLogin,DSSenha,BTAtivo FROM TB_Usuario WHERE IDUsuario = @IDUsuario", objConn);
                    cmd.Parameters.Add("@IDUsuario", OleDbType.Integer).Value = _IdUsuario;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        u.IDUsuario = Convert.ToInt32(dr["IDUsuario"]);
                        u.DSNome = dr["DSNome"].ToString();
                        u.DSLogin = dr["DSLogin"].ToString();
                        u.DSSenha = dr["DSSenha"].ToString();
                        u.BTAtivo = Convert.ToBoolean(dr["BTAtivo"]);
                    }

                    return u;
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

        public bool Autenticar(string _Login, string _Senha)
        {
            try
            {
                using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
                {
                    objConn.Open();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDUsuario FROM TB_Usuario WHERE DSLogin=@DSLogin And DSSenha=@DSSenha", objConn);
                    cmd.Parameters.Add("@DSLogin", OleDbType.VarChar, 15).Value = _Login;
                    cmd.Parameters.Add("@DSSenha", OleDbType.VarChar, 15).Value = _Senha;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        HttpContext.Current.Session["sesIDUsuario"] = dr["IDUsuario"];
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Alterar(object obj)
        {
            using (OleDbConnection objConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["DBASANM"].ConnectionString))
            {
                try
                {
                    objConn.Open();

                    Usuario u = (Usuario)obj;

                    OleDbCommand cmd = new OleDbCommand("UPDATE TB_Usuario SET DSNome=?,DSLogin=?,DSSenha=?,BTAtivo=? WHERE IDUsuario=?", objConn);
                    cmd.Parameters.Add("@DSNome", OleDbType.VarChar, 100).Value = u.DSNome;
                    cmd.Parameters.Add("@DSLogin", OleDbType.VarChar, 15).Value = u.DSLogin;
                    cmd.Parameters.Add("@DSSenha", OleDbType.VarChar, 15).Value = u.DSSenha;
                    cmd.Parameters.Add("@BTAtivo", OleDbType.Boolean).Value = u.BTAtivo;
                    cmd.Parameters.Add("@IDUsuario", OleDbType.Integer).Value = u.IDUsuario;
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

                    Usuario u = (Usuario)obj;

                    OleDbCommand cmd = new OleDbCommand("INSERT INTO TB_Usuario(DSNome,DSLogin,DSSenha,BTAtivo) VALUES(@DSNome,@DSLogin,@DSSenha,@BTAtivo)", objConn);
                    cmd.Parameters.Add("@DSNome", OleDbType.VarChar, 100).Value = u.DSNome;
                    cmd.Parameters.Add("@DSLogin", OleDbType.VarChar, 15).Value = u.DSLogin;
                    cmd.Parameters.Add("@DSSenha", OleDbType.VarChar, 15).Value = u.DSSenha;
                    cmd.Parameters.Add("@BTAtivo", OleDbType.Boolean).Value = u.BTAtivo;
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

                    Usuario u = (Usuario)obj;

                    OleDbCommand cmd = new OleDbCommand("DELETE FROM TB_Usuario WHERE IDUsuario = @IDUsuario", objConn);
                    cmd.Parameters.Add("@IDUsuario", OleDbType.Integer).Value = u.IDUsuario;
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

                    List<Usuario> lst = new List<Usuario>();

                    OleDbCommand cmd = new OleDbCommand("SELECT IDUsuario,DSNome,DSLogin,DSSenha,BTAtivo FROM TB_Usuario", objConn);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lst.Add(
                                new Usuario()
                                {
                                    IDUsuario = Convert.ToInt32(dr["IDUsuario"]),
                                    DSNome = dr["DSNome"].ToString(),
                                    DSLogin = dr["DSLogin"].ToString(),
                                    DSSenha = dr["DSSenha"].ToString(),
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
