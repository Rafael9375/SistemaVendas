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
    public class SegmentoEmpresaDAL
    {
        #region .: Contructor :.

        public SegmentoEmpresaDAL()
        {

        }

        #endregion

        #region .: Load :.

        /// <summary>
        /// Metodo para carregar os dados do banco em um unico objeto.
        /// </summary>
        /// <param name="drdSegmentoEmpresa"></param>
        /// <returns></returns>
        public static SegmentoEmpresaTO LoadDataBaseObject(IDataReader drdSegmentoEmpresa)
        {
            SegmentoEmpresaTO objSegmentoEmpresa = new SegmentoEmpresaTO();

            if (!drdSegmentoEmpresa.IsDBNull(drdSegmentoEmpresa.GetOrdinal("IdSegmentoEmpresa")))
                objSegmentoEmpresa.IdSegmentoEmpresa = drdSegmentoEmpresa.GetInt32(drdSegmentoEmpresa.GetOrdinal("IdSegmentoEmpresa"));
            else
                objSegmentoEmpresa.IdSegmentoEmpresa = 0;

            if (!drdSegmentoEmpresa.IsDBNull(drdSegmentoEmpresa.GetOrdinal("IdEmpresa")))
                objSegmentoEmpresa.IdEmpresa = drdSegmentoEmpresa.GetInt32(drdSegmentoEmpresa.GetOrdinal("IdEmpresa"));
            else
                objSegmentoEmpresa.IdEmpresa = 0;


            if (!drdSegmentoEmpresa.IsDBNull(drdSegmentoEmpresa.GetOrdinal("DesSegmento")))
                objSegmentoEmpresa.DesSegmento = drdSegmentoEmpresa.GetString(drdSegmentoEmpresa.GetOrdinal("DesSegmento"));
            else
                objSegmentoEmpresa.DesSegmento = string.Empty;

            if (!drdSegmentoEmpresa.IsDBNull(drdSegmentoEmpresa.GetOrdinal("Ativo")))
                objSegmentoEmpresa.Ativo = drdSegmentoEmpresa.GetBoolean(drdSegmentoEmpresa.GetOrdinal("Ativo"));
            else
                objSegmentoEmpresa.Ativo = false;

            return objSegmentoEmpresa;

        }

        /// <summary>
        /// Metodo para carregar os dados do banco em um objetos.
        /// </summary>
        /// <param name="drdTipoUsuario"></param>
        /// <returns></returns>
        private static SegmentoEmpresaTO LoadObject(IDataReader drdSegmentoEmpresa)
        {
            SegmentoEmpresaTO objSegmentoEmpresa = new SegmentoEmpresaTO();

            if (drdSegmentoEmpresa.Read())
            {
                objSegmentoEmpresa = LoadDataBaseObject(drdSegmentoEmpresa);
            }

            return objSegmentoEmpresa;
        }

        /// <summary>
        /// Metodo para carregar os dados do banco numa lista de objetos.
        /// </summary>
        /// <param name="drdSegmentoEmpresa"></param>
        /// <returns></returns>
        private static List<SegmentoEmpresaTO> LoadObjects(IDataReader drdSegmentoEmpresa)
        {
            List<SegmentoEmpresaTO> lstSegmentoEmpresa = new List<SegmentoEmpresaTO>();

            while (drdSegmentoEmpresa.Read())
            {
                lstSegmentoEmpresa.Add(LoadDataBaseObject(drdSegmentoEmpresa));
            }

            return lstSegmentoEmpresa;
        }

        #endregion

        #region .: Search :.

        /// <summary>
        /// Consulta por filtros
        /// </summary>
        /// <param name="objSegmentoEmpresaFiltro">Filtros desejados</param>
        /// <returns></returns>
        public List<SegmentoEmpresaTO> GetData(SegmentoEmpresaTO objSegmentoEmpresaFiltro)
        {
            List<SegmentoEmpresaTO> lstSegmentoEmpresa = new List<SegmentoEmpresaTO>();

            try
            {
                string order = string.Empty;
                string orderPaginacao = string.Empty;
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();

                StrSQL.Append(" SELECT IdSegmentoEmpresa, IdEmpresa, DesSegmento, Ativo FROM tb_SegmentoEmpresa");

                #region .:Filter:.

                if (objSegmentoEmpresaFiltro != null)
                {
                    StringBuilder StrSQLWhere = new StringBuilder();

                    if (objSegmentoEmpresaFiltro.IdSegmentoEmpresa > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_SegmentoEmpresa.IdSegmentoEmpresa = @IdSegmentoEmpresa");
                        Cmd.Parameters.AddWithValue("@IdSegmentoEmpresa", objSegmentoEmpresaFiltro.IdSegmentoEmpresa);
                    }

                    if (objSegmentoEmpresaFiltro.IdEmpresa > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_SegmentoEmpresa.IdEmpresa = @IdEmpresa");
                        Cmd.Parameters.AddWithValue("@IdEmpresa", objSegmentoEmpresaFiltro.IdEmpresa);
                    }

                    if (!string.IsNullOrWhiteSpace(objSegmentoEmpresaFiltro.DesSegmento))
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_SegmentoEmpresa.DesSegmento = @DesSegmento");
                        Cmd.Parameters.AddWithValue("@DesSegmento", objSegmentoEmpresaFiltro.DesSegmento);
                    }

                    if (objSegmentoEmpresaFiltro.Ativo)
                    {
                        if (!string.IsNullOrWhiteSpace(StrSQLWhere.ToString()))
                        {
                            StrSQLWhere.Append(" AND");
                        }

                        StrSQLWhere.Append(" tb_SegmentoEmpresa.Ativo = 1");
                        Cmd.Parameters.AddWithValue("@Ativo", 1);
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

                using (IDataReader drdSegmentoEmpresa = Cmd.ExecuteReader())
                {
                    lstSegmentoEmpresa = LoadObjects(drdSegmentoEmpresa);
                }
                Cmd.Connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstSegmentoEmpresa;
        }

        #endregion

        #region .: Persistence :.

        public SegmentoEmpresaTO Insert(SegmentoEmpresaTO objSegmentoEmpresa)
        {
            SegmentoEmpresaTO objSegmentoEmpresaRetorno = new SegmentoEmpresaTO();

            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" INSERT INTO tb_SegmentoEmpresa (IdEmpresa, DesSegmento, Ativo)");
                StrSQL.Append(" VALUES (@IdEmpresa, @DesSegmento, @Ativo); ");
                StrSQL.Append(" SELECT IdEmpresa, DesSegmento, Ativo FROM tb_SegmentoEmpresa WHERE IdSegmentoEmpresa=@@IDENTITY; ");

                Cmd.Parameters.AddWithValue("@IdEmpresa", objSegmentoEmpresa.IdEmpresa);
                Cmd.Parameters.AddWithValue("@DesSegmento", objSegmentoEmpresa.DesSegmento);
                Cmd.Parameters.AddWithValue("@Ativo", objSegmentoEmpresa.Ativo);


                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                Cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBVENDASContext"].ConnectionString);
                Cmd.Connection.Open();

                using (IDataReader drdSegmentoEmpresa = Cmd.ExecuteReader())
                {
                    objSegmentoEmpresaRetorno = LoadObject(drdSegmentoEmpresa);
                    drdSegmentoEmpresa.Close();
                }
                Cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objSegmentoEmpresaRetorno;
        }

        public void Update(SegmentoEmpresaTO objSegmentoEmpresa)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                StringBuilder StrSQL = new StringBuilder();
                StrSQL.Append(" SET NOCOUNT ON; ");
                StrSQL.Append(" UPDATE tb_SegmentoEmpresa SET IdEmpresa = @IdEmpresa, DesSegmento = @DesSegmento, Ativo = @Ativo ");
                StrSQL.Append(" WHERE IdSegmentoEmpresa = @IdSegmentoEmpresa; ");
                StrSQL.Append(" SELECT IdSegmentoEmpresa, IdEmpresa, DesSegmento, Ativo FROM tb_SegmentoEmpresa WHERE IdSegmentoEmpresa = @IdSegmentoEmpresa; ");

                Cmd.Parameters.AddWithValue("@IdEmpresa", objSegmentoEmpresa.IdEmpresa);
                Cmd.Parameters.AddWithValue("@DesSegmento", objSegmentoEmpresa.DesSegmento);
                Cmd.Parameters.AddWithValue("@Ativo", objSegmentoEmpresa.Ativo);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdSegmentoEmpresa = Cmd.ExecuteReader();
                drdSegmentoEmpresa.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Delete(SegmentoEmpresaTO objSegmentoEmpresa)
        {
            try
            {
                StringBuilder StrSQL = new StringBuilder();
                SqlCommand Cmd = new SqlCommand();
                StrSQL.Append(" DELETE FROM tb_SegmentoEmpresa WHERE IdSegmentoEmpresa = @IdSegmentoEmpresa; ");
                Cmd.Parameters.AddWithValue("@IdSegmentoEmpresa", objSegmentoEmpresa.IdSegmentoEmpresa);

                Cmd.CommandText = StrSQL.ToString();
                /*Conectar-se ao Banco de Dados*/

                IDataReader drdSegmentoEmpresa = Cmd.ExecuteReader();
                drdSegmentoEmpresa.Close();

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
