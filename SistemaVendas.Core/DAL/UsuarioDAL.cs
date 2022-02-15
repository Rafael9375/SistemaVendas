using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaVendas.Core.TO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SistemaVendas.Core.DAL
{
    public class UsuarioDAL 
    {
        #region .: Contructor :.

        public UsuarioDAL()
        {
           
        }

        #endregion

        #region .: Load :.

        /// <summary>
        /// Metodo para carregar os dados do banco em um unico objeto.
        /// </summary>
        /// <param name="drdUsuario"></param>
        /// <returns></returns>
        public static UsuarioTO LoadDataBaseObject(IDataReader drdUsuario)
        {
            UsuarioTO objUsuario = new UsuarioTO();

            if (!drdUsuario.IsDBNull(drdUsuario.GetOrdinal("IdUsuario")))
                objUsuario.IdUsuario = drdUsuario.GetInt32(drdUsuario.GetOrdinal("IdUsuario"));
            else
                objUsuario.IdUsuario = 0;
            if (!drdUsuario.IsDBNull(drdUsuario.GetOrdinal("Nome"))) objUsuario.Nome = drdUsuario.GetString(drdUsuario.GetOrdinal("Nome")); else objUsuario.Nome = string.Empty;
            if (!drdUsuario.IsDBNull(drdUsuario.GetOrdinal("DesLogin"))) objUsuario.DesLogin = drdUsuario.GetString(drdUsuario.GetOrdinal("DesLogin")); else objUsuario.DesLogin = string.Empty;
            if (!drdUsuario.IsDBNull(drdUsuario.GetOrdinal("Senha"))) objUsuario.Senha = drdUsuario.GetString(drdUsuario.GetOrdinal("Senha")); else objUsuario.Senha = string.Empty;
            if (!drdUsuario.IsDBNull(drdUsuario.GetOrdinal("CPF"))) objUsuario.CPF = drdUsuario.GetString(drdUsuario.GetOrdinal("CPF")); else objUsuario.CPF = string.Empty;
            if (!drdUsuario.IsDBNull(drdUsuario.GetOrdinal("RG"))) objUsuario.RG = drdUsuario.GetString(drdUsuario.GetOrdinal("RG")); else objUsuario.RG = null;
            if (!drdUsuario.IsDBNull(drdUsuario.GetOrdinal("Telefone"))) objUsuario.Telefone = drdUsuario.GetString(drdUsuario.GetOrdinal("Telefone")); else objUsuario.Telefone = null;
            
            return objUsuario;

        }

        /// <summary>
        /// Metodo para carregar os dados do banco em um objetos.
        /// </summary>
        /// <param name="drdTipoUsuario"></param>
        /// <returns></returns>
        private static UsuarioTO LoadObject(IDataReader drdUsuario)
        {
            UsuarioTO objUsuario = new UsuarioTO();

            if (drdUsuario.Read())
            {
                objUsuario = LoadDataBaseObject(drdUsuario);
            }

            return objUsuario;
        }

        /// <summary>
        /// Metodo para carregar os dados do banco numa lista de objetos.
        /// </summary>
        /// <param name="drdUsuario"></param>
        /// <returns></returns>
        private static List<UsuarioTO> LoadObjects(IDataReader drdUsuario)
        {
            List<UsuarioTO> lstUsuario = new List<UsuarioTO>();

            while (drdUsuario.Read())
            {
                lstUsuario.Add(LoadDataBaseObject(drdUsuario));
            }

            return lstUsuario;
        }

        #endregion

        #region .: Search :.

        /// <summary>
        /// Consulta por filtros
        /// </summary>
        /// <param name="objUsuarioFiltro">Filtros desejados</param>
        /// <returns></returns>
        public List<UsuarioTO> GetData(UsuarioTO objUsuarioFiltro)
        {
            List<UsuarioTO> lstUsuario = new List<UsuarioTO>();

            try
            {
                string order = string.Empty;
                string orderPaginacao = string.Empty;
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();

                StrSQL.Append(" SELECT IdUsuario,Nome,CPF,RG,Telefone,DesLogin,Senha FROM tb_Usuario");

                #region .:Filter:.

                if (objUsuarioFiltro != null)
                {
                    StringBuilder StrSQLWhere = new StringBuilder();

                    if (objUsuarioFiltro.IdUsuario > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Usuario.IdUsuario = @IdUsuario");
                        Cmd.Parameters.AddWithValue("@IdUsuario", objUsuarioFiltro.IdUsuario);
                    }

                    if (!string.IsNullOrWhiteSpace(objUsuarioFiltro.Nome))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Usuario.Nome = @Nome");
                        Cmd.Parameters.AddWithValue("@Nome", objUsuarioFiltro.Nome);
                    }

                    if (!string.IsNullOrWhiteSpace(objUsuarioFiltro.CPF))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Usuario.CPF = @CPF");
                        Cmd.Parameters.AddWithValue("@CPF", objUsuarioFiltro.CPF);
                    }

                    if (!string.IsNullOrWhiteSpace(objUsuarioFiltro.RG))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Usuario.RG = @RG");
                        Cmd.Parameters.AddWithValue("@RG", objUsuarioFiltro.RG);
                    }

                    if (!string.IsNullOrWhiteSpace(objUsuarioFiltro.Telefone))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Usuario.Telefone = @Telefone");
                        Cmd.Parameters.AddWithValue("@Telefone", objUsuarioFiltro.Telefone);
                    }

                    if (!string.IsNullOrWhiteSpace(objUsuarioFiltro.DesLogin))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Usuario.DesLogin = @DesLogin");
                        Cmd.Parameters.AddWithValue("@DesLogin", objUsuarioFiltro.DesLogin);
                    }
                    
                    if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                    {
                        StrSQL.Append(" WHERE").Append(StrSQLWhere.ToString());
                    }
                }

                #endregion

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/
                Cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBVENDASContext"].ConnectionString);
                Cmd.Connection.Open();

                using (IDataReader drdUsuario = Cmd.ExecuteReader())
                {
                    lstUsuario = LoadObjects(drdUsuario);
                }
                Cmd.Connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstUsuario;
        }

        #endregion

        #region .: Persistence :.

        public UsuarioTO Insert(UsuarioTO objUsuario)
        {
            UsuarioTO objUsuarioRetorno = new UsuarioTO();

            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" INSERT INTO tb_Usuario (Nome,CPF,RG,Telefone,DesLogin,Senha)");
                StrSQL.Append(" VALUES (@Nome,@CPF,@RG,@Telefone,@DesLogin,@Senha); ");
                StrSQL.Append(" SELECT IdUsuario,Nome,CPF,RG,Telefone,DesLogin,Senha FROM tb_Usuario WHERE IdUsuario=@@IDENTITY; ");

                Cmd.Parameters.AddWithValue("@IdUsuario", objUsuario.IdUsuario);
                Cmd.Parameters.AddWithValue("@Nome", objUsuario.Nome);
                Cmd.Parameters.AddWithValue("@DesLogin", objUsuario.DesLogin);
                Cmd.Parameters.AddWithValue("@Senha", objUsuario.Senha);
                Cmd.Parameters.AddWithValue("@CPF", objUsuario.CPF);
                Cmd.Parameters.AddWithValue("@RG", objUsuario.RG);
                Cmd.Parameters.AddWithValue("@Telefone", objUsuario.Telefone);
                

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                Cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBVENDASContext"].ConnectionString);
                Cmd.Connection.Open();

                using (IDataReader drdUsuario = Cmd.ExecuteReader())
                {
                    objUsuarioRetorno = LoadObject(drdUsuario);
                    drdUsuario.Close();
                }
                Cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objUsuarioRetorno;
        }

        public void Update(UsuarioTO objUsuario)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" UPDATE tb_Usuario SET Nome = @Nome,CPF = @CPF,RG = @RG,Telefone = @Telefone ,DesLogin = @DesLogin ,Senha = @Senha ");
                StrSQL.Append(" WHERE IdUsuario = @IdUsuario; ");
                StrSQL.Append(" SELECT IdUsuario,Nome,CPF,RG,Telefone,DesLogin,Senha FROM tb_Usuario WHERE IdUsuario = @IdUsuario; ");

                Cmd.Parameters.AddWithValue("@IdUsuario", objUsuario.IdUsuario);
                Cmd.Parameters.AddWithValue("@Nome", objUsuario.Nome);
                Cmd.Parameters.AddWithValue("@DesLogin", objUsuario.DesLogin);
                Cmd.Parameters.AddWithValue("@Senha", objUsuario.Senha);
                Cmd.Parameters.AddWithValue("@CPF", objUsuario.CPF);
                Cmd.Parameters.AddWithValue("@RG", objUsuario.RG);
                Cmd.Parameters.AddWithValue("@Telefone", objUsuario.Telefone);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdUsuario = Cmd.ExecuteReader();
                drdUsuario.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Delete(UsuarioTO objUsuario)
        {
            try
            {
                StringBuilder StrSQL = new StringBuilder();
                SqlCommand Cmd = new SqlCommand();
                StrSQL.Append(" DELETE FROM tb_Usuario WHERE IdUsuario = @IdUsuario; ");
                Cmd.Parameters.AddWithValue("@IdUsuario", objUsuario.IdUsuario);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdUsuario = Cmd.ExecuteReader();
                drdUsuario.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioTO Login(UsuarioTO objUsuario)
        {
            UsuarioTO usuario = new UsuarioTO();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBVENDASContext"].ConnectionString);
                command.CommandText = "select top 1 * from tb_Usuario where DesLogin = @desLogin and Senha = @senha";
                command.Parameters.AddWithValue("@desLogin", objUsuario.DesLogin);
                command.Parameters.AddWithValue("@senha", objUsuario.Senha);
                command.Connection.Open();
                using (IDataReader drdUsuario = command.ExecuteReader())
                {
                    usuario = LoadObject(drdUsuario);
                }
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
        }

        #endregion
    }
}
