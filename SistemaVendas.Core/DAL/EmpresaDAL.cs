using SistemaVendas.Core.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SistemaVendas.Core.DAL
{
    public class EmpresaDAL
    {
        #region .: Contructor :.

        public EmpresaDAL()
        {

        }

        #endregion

        #region .: Load :.

        /// <summary>
        /// Metodo para carregar os dados do banco em um unico objeto.
        /// </summary>
        /// <param name="drdEmpresa"></param>
        /// <returns></returns>
        public static EmpresaTO LoadDataBaseObject(IDataReader drdEmpresa)
        {
            EmpresaTO objEmpresa = new EmpresaTO();

            if (!drdEmpresa.IsDBNull(drdEmpresa.GetOrdinal("IdEmpresa")))
                objEmpresa.IdEmpresa = drdEmpresa.GetInt32(drdEmpresa.GetOrdinal("IdEmpresa"));
            else
                objEmpresa.IdEmpresa = 0;

            if (!drdEmpresa.IsDBNull(drdEmpresa.GetOrdinal("IdUsuarioCadastro")))
                objEmpresa.IdUsuarioCadastro = drdEmpresa.GetInt32(drdEmpresa.GetOrdinal("IdUsuarioCadastro"));
            else
                objEmpresa.IdUsuarioCadastro = 0;

            if (!drdEmpresa.IsDBNull(drdEmpresa.GetOrdinal("RazaoSocial")))
                objEmpresa.RazaoSocial = drdEmpresa.GetString(drdEmpresa.GetOrdinal("RazaoSocial"));
            else
                objEmpresa.RazaoSocial = string.Empty;

            if (!drdEmpresa.IsDBNull(drdEmpresa.GetOrdinal("CNPJ")))
                objEmpresa.CNPJ = drdEmpresa.GetString(drdEmpresa.GetOrdinal("CNPJ"));
            else
                objEmpresa.CNPJ = string.Empty;

            if (!drdEmpresa.IsDBNull(drdEmpresa.GetOrdinal("Endereco")))
                objEmpresa.Endereco = drdEmpresa.GetString(drdEmpresa.GetOrdinal("Endereco"));
            else
                objEmpresa.Endereco = string.Empty;

            if (!drdEmpresa.IsDBNull(drdEmpresa.GetOrdinal("Telefone")))
                objEmpresa.Telefone = drdEmpresa.GetString(drdEmpresa.GetOrdinal("Telefone"));
            else
                objEmpresa.Telefone = null;

            return objEmpresa;

        }

        /// <summary>
        /// Metodo para carregar os dados do banco em um objetos.
        /// </summary>
        /// <param name="drdTipoUsuario"></param>
        /// <returns></returns>
        private static EmpresaTO LoadObject(IDataReader drdEmpresa)
        {
            EmpresaTO objEmpresa = new EmpresaTO();

            if (drdEmpresa.Read())
            {
                objEmpresa = LoadDataBaseObject(drdEmpresa);
            }

            return objEmpresa;
        }

        /// <summary>
        /// Metodo para carregar os dados do banco numa lista de objetos.
        /// </summary>
        /// <param name="drdEmpresa"></param>
        /// <returns></returns>
        private static List<EmpresaTO> LoadObjects(IDataReader drdEmpresa)
        {
            List<EmpresaTO> lstEmpresa = new List<EmpresaTO>();

            while (drdEmpresa.Read())
            {
                lstEmpresa.Add(LoadDataBaseObject(drdEmpresa));
            }

            return lstEmpresa;
        }

        #endregion

        #region .: Search :.

        /// <summary>
        /// Consulta por filtros
        /// </summary>
        /// <param name="objEmpresaFiltro">Filtros desejados</param>
        /// <returns></returns>
        public List<EmpresaTO> GetData(EmpresaTO objEmpresaFiltro)
        {
            List<EmpresaTO> lstEmpresa = new List<EmpresaTO>();

            try
            {
                string order = string.Empty;
                string orderPaginacao = string.Empty;
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();

                StrSQL.Append(" SELECT IdEmpresa,IdUsuarioCadastro,RazaoSocial,CNPJ,Endereco,Telefone FROM tb_Empresa");

                #region .:Filter:.

                if (objEmpresaFiltro != null)
                {
                    StringBuilder StrSQLWhere = new StringBuilder();

                    if (objEmpresaFiltro.IdEmpresa > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Empresa.IdEmpresa = @IdEmpresa");
                        Cmd.Parameters.AddWithValue("@IdEmpresa", objEmpresaFiltro.IdEmpresa);
                    }

                    if (objEmpresaFiltro.IdUsuarioCadastro > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Empresa.IdUsuarioCadastro = @IdUsuarioCadastro");
                        Cmd.Parameters.AddWithValue("@IdUsuarioCadastro", objEmpresaFiltro.IdUsuarioCadastro);
                    }

                    if (!string.IsNullOrWhiteSpace(objEmpresaFiltro.RazaoSocial))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Empresa.RazaoSocial = @RazaoSocial");
                        Cmd.Parameters.AddWithValue("@RazaoSocial", objEmpresaFiltro.RazaoSocial);
                    }

                    if (!string.IsNullOrWhiteSpace(objEmpresaFiltro.CNPJ))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Empresa.CNPJ = @CNPJ");
                        Cmd.Parameters.AddWithValue("@CNPJ", objEmpresaFiltro.CNPJ);
                    }

                    if (!string.IsNullOrWhiteSpace(objEmpresaFiltro.Endereco))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Empresa.Endereco = @Endereco");
                        Cmd.Parameters.AddWithValue("@Endereco", objEmpresaFiltro.Endereco);
                    }

                    if (!string.IsNullOrWhiteSpace(objEmpresaFiltro.Telefone))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Empresa.Telefone = @Telefone");
                        Cmd.Parameters.AddWithValue("@Telefone", objEmpresaFiltro.Telefone);
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

                using (IDataReader drdEmpresa = Cmd.ExecuteReader())
                {
                    lstEmpresa = LoadObjects(drdEmpresa);
                }
                Cmd.Connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstEmpresa;
        }

        #endregion

        #region .: Persistence :.

        public EmpresaTO Insert(EmpresaTO objEmpresa)
        {
            EmpresaTO objEmpresaRetorno = new EmpresaTO();

            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" INSERT INTO tb_Empresa (IdUsuarioCadastro, RazaoSocial, CNPJ, Endereco, Telefone)");
                StrSQL.Append(" VALUES (@IdUsuarioCadastro, @RazaoSocial, @CNPJ, @Endereco, @Telefone); ");
                StrSQL.Append(" SELECT IdEmpresa, IdUsuarioCadastro, RazaoSocial, CNPJ, Endereco, Telefone FROM tb_Empresa WHERE IdEmpresa=@@IDENTITY; ");

                Cmd.Parameters.AddWithValue("@IdEmpresa", objEmpresa.IdEmpresa);
                if (objEmpresa.IdUsuarioCadastro == 0)
                {
                    Cmd.Parameters.Add(new SqlParameter("@IdUsuarioCadastro", DBNull.Value));
                }
                else
                {
                    Cmd.Parameters.AddWithValue("@IdUsuarioCadastro", objEmpresa.IdUsuarioCadastro);
                }
                Cmd.Parameters.AddWithValue("@RazaoSocial", objEmpresa.RazaoSocial);
                Cmd.Parameters.AddWithValue("@CNPJ", objEmpresa.CNPJ);
                Cmd.Parameters.AddWithValue("@Endereco", objEmpresa.Endereco);
                Cmd.Parameters.AddWithValue("@Telefone", objEmpresa.Telefone);


                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                Cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBVENDASContext"].ConnectionString);
                Cmd.Connection.Open();

                using (IDataReader drdEmpresa = Cmd.ExecuteReader())
                {
                    objEmpresaRetorno = LoadObject(drdEmpresa);
                    drdEmpresa.Close();
                }
                Cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objEmpresaRetorno;
        }

        public void Update(EmpresaTO objEmpresa)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" UPDATE tb_Empresa SET RazaoSocial = @RazaoSocial, CNPJ = @CNPJ, Endereco = @Endereco, Telefone = @Telefone ");
                StrSQL.Append(" WHERE IdEmpresa = @IdEmpresa; ");
                StrSQL.Append(" SELECT IdEmpresa, RazaoSocial, CNPJ, Endereco, Telefone FROM tb_Usuario WHERE IdUsuario = @IdEmpresa; ");

                Cmd.Parameters.AddWithValue("@IdEmpresa", objEmpresa.IdEmpresa);
                Cmd.Parameters.AddWithValue("@RazaoSocial", objEmpresa.RazaoSocial);
                Cmd.Parameters.AddWithValue("@CNPJ", objEmpresa.CNPJ);
                Cmd.Parameters.AddWithValue("@Endereco", objEmpresa.Endereco);
                Cmd.Parameters.AddWithValue("@Telefone", objEmpresa.Telefone);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdEmpresa = Cmd.ExecuteReader();
                drdEmpresa.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Delete(EmpresaTO objEmpresa)
        {
            try
            {
                StringBuilder StrSQL = new StringBuilder();
                SqlCommand Cmd = new SqlCommand();
                StrSQL.Append(" DELETE FROM tb_Empresa WHERE IdEmpresa = @IdEmpresa; ");
                Cmd.Parameters.AddWithValue("@IdEmpresa", objEmpresa.IdEmpresa);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdEmpresa = Cmd.ExecuteReader();
                drdEmpresa.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
