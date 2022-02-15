using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas.Core.TO
{
    [Serializable()]
    public class EmpresaTO
    {
        #region .: Constructor :.

        public EmpresaTO()
        {

        }

        #endregion

        #region .: Variables :.

        private int _idEmpresa;
        private int _idUsuarioCadastro;
        private String _razaoSocial;
        private String _cNPJ;
        private String _endereco;
        private String _telefone;

        #endregion

        #region .:Properties:.

        public int IdEmpresa
        {
            get
            {
                return _idEmpresa;
            }
            set
            {
                _idEmpresa = value;
            }
        }

        public int IdUsuarioCadastro
        {
            get
            {
                return _idUsuarioCadastro;
            }
            set
            {
                _idUsuarioCadastro = value;
            }
        }

        public String RazaoSocial
        {
            get
            {
                return _razaoSocial;
            }
            set
            {
                _razaoSocial = value;
            }
        }

        public String CNPJ
        {
            get
            {
                return _cNPJ;
            }
            set
            {
                _cNPJ = value;
            }
        }
        public String Endereco
        {
            get
            {
                return _endereco;
            }
            set
            {
                _endereco = value;
            }
        }

        public String Telefone
        {
            get
            {
                return _telefone;
            }
            set
            {
                _telefone = value;
            }
        }

        #endregion
    }
}
