using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVendas.Core.TO
{
    [Serializable()]
    public class SegmentoEmpresaTO
    {
        #region .: Constructor :.

        public SegmentoEmpresaTO()
        {

        }

        #endregion

        #region .: Variables :.

        private int _idSegmentoEmpresa;
        private int _idEmpresa;
        private String _desSegmento;
        private bool _ativo;

        #endregion

        #region .:Properties:.

        public int IdSegmentoEmpresa
        {
            get
            {
                return _idSegmentoEmpresa;
            }
            set
            {
                _idSegmentoEmpresa = value;
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

        public String DesSegmento
        {
            get
            {
                return _desSegmento;
            }
            set
            {
                _desSegmento = value;
            }
        }

        public bool Ativo
        {
            get
            {
                return _ativo;
            }
            set
            {
                _ativo = value;
            }
        }

        #endregion
    }
}
