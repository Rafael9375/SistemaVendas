using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaVendas.Core.BLL;

namespace SistemaVendas.Core.TO
{
    [Serializable()]
    public class UsuarioTO
    {
        #region .: Constructor :.

        public UsuarioTO()
        { }

        #endregion

        #region .: Variables :.

        private int _idUsuario;
        private String _nome;
        private String _deslogin;
        private String _senha;
        private String _cPF;
        private String _rg;
        private String _telefone;

        #endregion

        #region .:Properties:.

        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }
        
        public String Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
            }
        }
        public String DesLogin
        {
            get
            {
                return _deslogin;
            }
            set
            {
                _deslogin = value;
            }
        }
        public String Senha
        {
            get
            {
                return _senha;
            }
            set
            {
                _senha = value;
            }
        }
        public String CPF
        {
            get
            {
                return _cPF;
            }
            set
            {
                _cPF = value;
            }
        }
        
        public String RG
        {
            get
            {
                return _rg;
            }
            set
            {
                _rg = value;
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
