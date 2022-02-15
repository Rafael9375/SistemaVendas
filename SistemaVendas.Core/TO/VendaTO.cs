using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas.Core.TO
{
    [Serializable()]
    public class VendaTO
    {
        #region .: Constructor :.

        public VendaTO()
        { }

        #endregion

        #region .: Variables :.

        private int _idVenda;
        private int _idEmpresa;
        private int _idUsuarioCadastro;
        private decimal _valorVenda;
        private DateTime? _dataVenda;
        private bool _emitidoNF;

        #endregion

        #region .:Properties:.

        public int IdVenda
        {
            get
            {
                return _idVenda;
            }
            set
            {
                _idVenda = value;
            }
        }
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
        public decimal ValorVenda
        {
            get
            {
                return _valorVenda;
            }
            set
            {
                _valorVenda = value;
            }
        }
        public DateTime? DataVenda
        {
            get
            {
                return _dataVenda;
            }
            set
            {
                _dataVenda = value;
            }
        }
        public bool EmitidoNF
        {
            get
            {
                return _emitidoNF;
            }
            set
            {
                _emitidoNF = value;
            }
        }

        #endregion
    }
}
