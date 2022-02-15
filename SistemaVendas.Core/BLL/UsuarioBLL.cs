using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaVendas.Core.TO;
using SistemaVendas.Core.DAL;

namespace SistemaVendas.Core.BLL
{
    public class UsuarioBLL
    {
        #region .: Constructor :.

        public UsuarioBLL()
        {
            
        }
        
        #endregion

        #region .: Methods :.

        private void ValidateData(UsuarioTO objUsuario)
        {
            Exception errors = new Exception();
            StringBuilder sbErrors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(objUsuario.DesLogin))
            {
                sbErrors.AppendLine("-Informe o campo login! <br>");
            }

            if (objUsuario.IdUsuario.Equals(0))
            {
                if (string.IsNullOrWhiteSpace(objUsuario.Senha))
                {
                    sbErrors.AppendLine("-Informe o campo senha! <br>");
                }
            }

            if (!string.IsNullOrWhiteSpace(sbErrors.ToString()))
            {
                errors = new Exception(sbErrors.ToString());
                throw errors;
            }
        }

        #endregion

        #region .: Search :.

        public List<UsuarioTO> GetData(UsuarioTO objUsuarioFiltro)
        {
            List<UsuarioTO> lstUsuario = new List<UsuarioTO>();
            UsuarioDAL objUsuarioDAL = new UsuarioDAL();

            try
            {
                lstUsuario = objUsuarioDAL.GetData(objUsuarioFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstUsuario;
        }

        #endregion

        #region .: Persistence :.

        public UsuarioTO Save(UsuarioTO objUsuario)
        {
            UsuarioTO objUsuarioRetorno = new UsuarioTO();
            UsuarioDAL objUsuarioDAL = new UsuarioDAL();

            try
            {
                ValidateData(objUsuario);

                if (objUsuario != null && objUsuario.IdUsuario > 0)
                {
                    objUsuarioDAL.Update(objUsuario);
                    objUsuarioRetorno = objUsuario;
                }
                else
                {
                    objUsuarioRetorno = objUsuarioDAL.Insert(objUsuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objUsuarioRetorno;
        }

        
        public Boolean DeleteUsuario(UsuarioTO objUsuario)
        {
            Boolean retorno = false;
            UsuarioDAL objUsuarioDAL = new UsuarioDAL();
            
            try
            {
                retorno = objUsuarioDAL.Delete(objUsuario);
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