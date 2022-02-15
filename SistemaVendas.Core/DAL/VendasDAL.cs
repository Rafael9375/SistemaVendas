using SistemaVendas.Core.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SistemaVenda.Core.DAL
{
    public class VendaDAL
    {
        #region .: Contructor :.

        public VendaDAL()
        {

        }

        #endregion

        #region .: Load :.

        /// <summary>
        /// Metodo para carregar os dados do banco em um unico objeto.
        /// </summary>
        /// <param name="drdVenda"></param>
        /// <returns></returns>
        public static VendaTO LoadDataBaseObject(IDataReader drdVenda)
        {
            VendaTO objVenda = new VendaTO();

            if (!drdVenda.IsDBNull(drdVenda.GetOrdinal("IdVenda")))
                objVenda.IdVenda = drdVenda.GetInt32(drdVenda.GetOrdinal("IdVenda"));
            else
                objVenda.IdVenda = 0;

            if (!drdVenda.IsDBNull(drdVenda.GetOrdinal("IdEmpresa")))
                objVenda.IdEmpresa = drdVenda.GetInt32(drdVenda.GetOrdinal("IdEmpresa"));
            else
                objVenda.IdEmpresa = 0;

            if (!drdVenda.IsDBNull(drdVenda.GetOrdinal("IdUsuarioCadastro")))
                objVenda.IdUsuarioCadastro = drdVenda.GetInt32(drdVenda.GetOrdinal("IdUsuarioCadastro"));
            else
                objVenda.IdUsuarioCadastro = 0;

            if (!drdVenda.IsDBNull(drdVenda.GetOrdinal("ValorVenda")))
                objVenda.ValorVenda = drdVenda.GetDecimal(drdVenda.GetOrdinal("ValorVenda"));
            else
                objVenda.ValorVenda = 0;

            if (!drdVenda.IsDBNull(drdVenda.GetOrdinal("DataVenda")))
                objVenda.DataVenda = drdVenda.GetDateTime (drdVenda.GetOrdinal("DataVenda"));
            else
                objVenda.DataVenda = null;

            if (!drdVenda.IsDBNull(drdVenda.GetOrdinal("EmitidoNF")))
                objVenda.EmitidoNF = drdVenda.GetBoolean(drdVenda.GetOrdinal("EmitidoNF"));
            else
                objVenda.EmitidoNF = false;

            return objVenda;

        }

        /// <summary>
        /// Metodo para carregar os dados do banco em um objetos.
        /// </summary>
        /// <param name="drdTipoUsuario"></param>
        /// <returns></returns>
        private static VendaTO LoadObject(IDataReader drdVenda)
        {
            VendaTO objVenda = new VendaTO();

            if (drdVenda.Read())
            {
                objVenda = LoadDataBaseObject(drdVenda);
            }

            return objVenda;
        }

        /// <summary>
        /// Metodo para carregar os dados do banco numa lista de objetos.
        /// </summary>
        /// <param name="drdVenda"></param>
        /// <returns></returns>
        private static List<VendaTO> LoadObjects(IDataReader drdVenda)
        {
            List<VendaTO> lstVenda = new List<VendaTO>();

            while (drdVenda.Read())
            {
                lstVenda.Add(LoadDataBaseObject(drdVenda));
            }

            return lstVenda;
        }

        #endregion

        #region .: Search :.

        /// <summary>
        /// Consulta por filtros
        /// </summary>
        /// <param name="objVendaFiltro">Filtros desejados</param>
        /// <returns></returns>
        public List<VendaTO> GetData(VendaTO objVendaFiltro)
        {
            List<VendaTO> lstVenda = new List<VendaTO>();

            try
            {
                string order = string.Empty;
                string orderPaginacao = string.Empty;
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();

                StrSQL.Append(" SELECT IdVenda, IdEmpresa, IdUsuarioCadastro, ValorVenda, DataVenda, EmitidoNF FROM tb_Vendas");

                #region .:Filter:.

                if (objVendaFiltro != null)
                {
                    StringBuilder StrSQLWhere = new StringBuilder();

                    if (objVendaFiltro.IdVenda > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Vendas.IdVenda = @IdVenda");
                        Cmd.Parameters.AddWithValue("@IdVenda", objVendaFiltro.IdVenda);
                    }

                    if (objVendaFiltro.IdEmpresa > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Vendas.IdEmpresa = @IdEmpresa");
                        Cmd.Parameters.AddWithValue("@IdEmpresa", objVendaFiltro.IdEmpresa);
                    }

                    if (objVendaFiltro.IdUsuarioCadastro > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Vendas.IdEmpresa = @IdUsuarioCadastro");
                        Cmd.Parameters.AddWithValue("@IdUsuarioCadastro", objVendaFiltro.IdUsuarioCadastro);
                    }

                    if (objVendaFiltro.ValorVenda > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Vendas.ValorVenda = @ValorVenda");
                        Cmd.Parameters.AddWithValue("@ValorVenda", objVendaFiltro.ValorVenda);
                    }

                    if (objVendaFiltro.EmitidoNF)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Vendas.EmitidoNF = 1");
                        Cmd.Parameters.AddWithValue("@EmitidoNF", 1);
                    }

                    if (objVendaFiltro.DataVenda != null)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_Vendas.DataVenda = @DataVenda");
                        Cmd.Parameters.AddWithValue("@DataVenda", objVendaFiltro.DataVenda);
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

                using (IDataReader drdVenda = Cmd.ExecuteReader())
                {
                    lstVenda = LoadObjects(drdVenda);
                }
                Cmd.Connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstVenda;
        }

        #endregion

        #region .: Persistence :.

        public VendaTO Insert(VendaTO objVenda)
        {
            VendaTO objVendaRetorno = new VendaTO();

            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" INSERT INTO tb_Vendas (IdEmpresa, IdUsuarioCadastro, ValorVenda, DataVenda, EmitidoNF)");
                StrSQL.Append(" VALUES (@IdEmpresa, @IdUsuarioCadastro, @ValorVenda, @DataVenda, @EmitidoNF); ");
                StrSQL.Append(" SELECT IdVenda, IdEmpresa, IdUsuarioCadastro, ValorVenda, DataVenda, EmitidoNF FROM tb_Vendas WHERE IdVenda=@@IDENTITY; ");

                Cmd.Parameters.AddWithValue("@IdEmpresa", objVenda.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdUsuarioCadastro", objVenda.IdUsuarioCadastro);
                Cmd.Parameters.AddWithValue("@ValorVenda", objVenda.ValorVenda);
                Cmd.Parameters.AddWithValue("@DataVenda", objVenda.DataVenda);
                Cmd.Parameters.AddWithValue("@EmitidoNF", objVenda.EmitidoNF);


                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                Cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBVENDASContext"].ConnectionString);
                Cmd.Connection.Open();

                using (IDataReader drdVenda = Cmd.ExecuteReader())
                {
                    objVendaRetorno = LoadObject(drdVenda);
                    drdVenda.Close();
                }
                Cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objVendaRetorno;
        }

        public void Update(VendaTO objVenda)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" UPDATE tb_Vendas SET IdEmpresa = @IdEmpresa, IdUsuarioCadastro = @IdUsuarioCadastro, ValorVenda = @ValorVenda, DataVenda = @DataVenda, EmitidoNF = @EmitidoNF ");
                StrSQL.Append(" WHERE IdVenda = @IdVenda; ");
                StrSQL.Append(" SELECT IdVenda, IdEmpresa, IdUsuarioCadastro, ValorVenda, DataVenda, EmitidoNF FROM tb_Vendas WHERE IdVenda = @IdVenda; ");

                Cmd.Parameters.AddWithValue("@IdVenda", objVenda.IdVenda);
                Cmd.Parameters.AddWithValue("@IdEmpresa", objVenda.IdEmpresa);
                Cmd.Parameters.AddWithValue("@IdUsuarioCadastro", objVenda.IdUsuarioCadastro);
                Cmd.Parameters.AddWithValue("@ValorVenda", objVenda.ValorVenda);
                Cmd.Parameters.AddWithValue("@DataVenda", objVenda.DataVenda);
                Cmd.Parameters.AddWithValue("@EmitidoNF", objVenda.EmitidoNF);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdVenda = Cmd.ExecuteReader();
                drdVenda.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Delete(VendaTO objVenda)
        {
            try
            {
                StringBuilder StrSQL = new StringBuilder();
                SqlCommand Cmd = new SqlCommand();
                StrSQL.Append(" DELETE FROM tb_Vendas WHERE IdVenda = @IdVenda; ");
                Cmd.Parameters.AddWithValue("@IdVenda", objVenda.IdVenda);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdVenda = Cmd.ExecuteReader();
                drdVenda.Close();

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
