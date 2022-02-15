using SistemaVendas.Core.DAL;
using SistemaVendas.Core.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas.Core.BLL
{
    public class EmpresaBLL
    {
        #region .: Constructor :.

        public EmpresaBLL()
        {

        }

        #endregion

        #region .: Methods :.

        private void ValidateData(EmpresaTO objEmpresa)
        {
            Exception errors = new Exception();
            StringBuilder sbErrors = new StringBuilder();

            if (objEmpresa.IdUsuarioCadastro == 0)
            {
                sbErrors.AppendLine("-Necessário efetuar o login! <br>");
            }

            if (!string.IsNullOrWhiteSpace(sbErrors.ToString()))
            {
                errors = new Exception(sbErrors.ToString());
                throw errors;
            }
        }

        #endregion

        #region .: Search :.

        public List<EmpresaTO> GetData(EmpresaTO objEmpresaFiltro)
        {
            List<EmpresaTO> lstEmpresa = new List<EmpresaTO>();
            EmpresaDAL objEmpresaDAL = new EmpresaDAL();

            try
            {
                lstEmpresa = objEmpresaDAL.GetData(objEmpresaFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstEmpresa;
        }

        #endregion

        #region .: Persistence :.

        public EmpresaTO Save(EmpresaTO objEmpresa)
        {
            EmpresaTO objEmpresaRetorno = new EmpresaTO();
            EmpresaDAL objEmpresaDAL = new EmpresaDAL();

            try
            {
                ValidateData(objEmpresa);

                if (objEmpresa != null && objEmpresa.IdEmpresa > 0)
                {
                    objEmpresaDAL.Update(objEmpresa);
                    objEmpresaRetorno = objEmpresa;
                }
                else
                {
                    objEmpresaRetorno = objEmpresaDAL.Insert(objEmpresa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objEmpresaRetorno;
        }


        public Boolean DeleteEmpresa(EmpresaTO objEmpresa)
        {
            Boolean retorno = false;
            EmpresaDAL objEmpresaDAL = new EmpresaDAL();

            try
            {
                retorno = objEmpresaDAL.Delete(objEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion
    }
}
