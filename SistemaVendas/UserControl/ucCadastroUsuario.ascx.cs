using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaVendas.Core.TO;
using SistemaVendas.Core.BLL;
using System.Text;

namespace SistemaVendas.Web.UserControl
{
    public partial class ucCadastroUsuario : System.Web.UI.UserControl
    {
        #region .: Delegate :.

        public delegate void CarregarGrid(int pagina);
        public event CarregarGrid CarregarPagina;

        #endregion

        #region .: Variables :.

        public int idUsuario
        {
            get
            {
                if (ViewState["idUsuario"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)ViewState["idUsuario"];
                }
            }
            set
            {
                ViewState.Add("idUsuario", value);
            }
        }

        #endregion

        #region .: Page Load :.

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        #endregion

        #region .: Methods :.

        /// <summary>
        /// Carrega os dados do usuario
        /// </summary>
        public void LoadDataFields(int IdUsuario)
        {
            UsuarioTO objUsuarioFilter = new UsuarioTO();
            UsuarioTO objUsuarioTO = new UsuarioTO();
            List<UsuarioTO> lstUsuario = new List<UsuarioTO>();
            UsuarioBLL objUsuarioBLL = new UsuarioBLL();

            objUsuarioFilter.IdUsuario = IdUsuario;
            lstUsuario = objUsuarioBLL.GetData(objUsuarioFilter);

            if (lstUsuario != null && lstUsuario.Count > 0)
            {
                objUsuarioTO = lstUsuario.FirstOrDefault();
                idUsuario = objUsuarioTO.IdUsuario;
                txtCpf.Text = objUsuarioTO.CPF;
                txtLogin.Text = objUsuarioTO.DesLogin;
                txtTelefone.Text = objUsuarioTO.Telefone;
                txtNome.Text = objUsuarioTO.Nome;
                txtRG.Text = objUsuarioTO.RG;
                txtSenha.Text = objUsuarioTO.Senha;

                updFilters.Update();
            }
        }

        /// <summary>
        /// Coletar os dados tela para cadastro/alteração
        /// </summary>
        /// <returns></returns>
        private UsuarioTO GetData()
        {
            UsuarioTO objUsuarioTO = new UsuarioTO();

            if (idUsuario > 0)
            {
                objUsuarioTO.IdUsuario = idUsuario;
            }

            objUsuarioTO.Senha = txtSenha.Text;
            objUsuarioTO.CPF = txtCpf.Text;
            objUsuarioTO.DesLogin = txtLogin.Text;
            objUsuarioTO.Telefone = txtTelefone.Text;
            objUsuarioTO.Nome = txtNome.Text;
            objUsuarioTO.RG = txtRG.Text;

            return objUsuarioTO;
        }

        /// <summary>
        /// Limpa os filtros após a gravação dos dados
        /// </summary>
        public void ClearFields()
        {
            idUsuario = 0;
            txtTelefone.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtRG.Text = string.Empty;
            txtNome.Text = string.Empty;

            updFilters.Update();
        }


        /// <summary>
        /// Salvar dados da cadastrados
        /// </summary>
        private void Save()
        {
            try
            {
                UsuarioTO objUsuarioTO = GetData();
                UsuarioTO objUsuarioCadastradoTO = new UsuarioTO();
                UsuarioBLL objUsuarioBLL = new UsuarioBLL();

                objUsuarioCadastradoTO = objUsuarioBLL.Save(objUsuarioTO);

                idUsuario = objUsuarioCadastradoTO.IdUsuario;

                CarregarPagina(1);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region .: Events :.

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                /*Exibir mensagem de erro*/
            }
        }

        
        #endregion
    }
}