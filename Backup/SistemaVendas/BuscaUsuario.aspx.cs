using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaVendas.Core.TO;
using SistemaVendas.Core.BLL;

namespace SistemaVendas.Web
{
    public partial class BuscaUsuario : System.Web.UI.Page
    {
        #region .: Page Load :.

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadFilters();
                pnlUsuario.Visible = false;
            }

            ucCadastroUsuario.CarregarPagina += new SistemaVendas.Web.UserControl.ucCadastroUsuario.CarregarGrid(LoadGridAfterModalSave);
        }

        #endregion

        #region .: Methods :.

        /// <summary>
        /// Carregar os dados da tela
        /// </summary>
        private void LoadFilters()
        {
            updFilters.Update();
        }

        /// <summary>
        /// Carregar grid de perfil de usuario
        /// </summary>
        /// <param name="pagina"></param>
        private void LoadGrid(int pagina)
        {
            UsuarioTO objUsuarioFilter = GetData();
            List<UsuarioTO> lstUsuario = new List<UsuarioTO>();
            UsuarioBLL objUsuarioBLL = new UsuarioBLL();

            lstUsuario = objUsuarioBLL.GetData(objUsuarioFilter);
            gdvUsuario.DataSource = lstUsuario;
            gdvUsuario.DataBind();
            pnlUsuario.Visible = true;
            updGrid.Update();
        }

        private void LoadGridAfterModalSave(int pagina)
        {
            LoadGrid(1);
        }

        /// <summary>
        /// Coletar os dados dela para cadastro/alteração
        /// </summary>
        /// <returns></returns>
        private UsuarioTO GetData()
        {
            UsuarioTO objUsuarioTO = new UsuarioTO();

            objUsuarioTO.Nome = txtNome.Text;
            objUsuarioTO.DesLogin = txtLogin.Text;
            objUsuarioTO.RG = txtRG.Text;
            objUsuarioTO.CPF = txtCpf.Text;
            objUsuarioTO.Telefone = txtTelefone.Text;
            objUsuarioTO.Senha = txtSenha.Text;

            return objUsuarioTO;
        }

        /// <summary>
        /// Limpa os filtros após a gravação dos dados
        /// </summary>
        private void ClearFields()
        {
            LoadFilters();
        }

        #endregion

        #region .: Events :.

        protected void gdvUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    UsuarioTO objUsuario = (UsuarioTO)e.Row.DataItem;

                    Label lblNome = (Label)e.Row.FindControl("lblNome");
                    Label lblLogin = (Label)e.Row.FindControl("lblLogin");
                    Label lblCPF = (Label)e.Row.FindControl("lblCPF");
                    ImageButton ibtDetalhes = (ImageButton)e.Row.FindControl("ibtDetalhes");

                    lblNome.Text = objUsuario.Nome;
                    lblLogin.Text = objUsuario.DesLogin;
                    lblCPF.Text = objUsuario.CPF;

                    ibtDetalhes.CommandArgument = objUsuario.IdUsuario.ToString();
                }
            }
            catch
            {
                /*Exibir Mensagem de Erro*/
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid(1);
            }
            catch
            {
                /*Exibir Mensagem de Erro*/
            }
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                ucCadastroUsuario.ClearFields();
                mpeCadastroUsuario.Show();
            }
            catch
            {
                /*Exibir Mensagem de Erro*/
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch
            {
                /*Exibir Mensagem de Erro*/
            }
        }

        protected void ibtDetalhes_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                long idUsuario = 0;
                ImageButton ibtDetalhes = (ImageButton)sender;

                if (long.TryParse(ibtDetalhes.CommandArgument, out idUsuario))
                {
                    ucCadastroUsuario.LoadDataFields(idUsuario);
                    mpeCadastroUsuario.Show();
                    updGrid.Update();
                }
            }
            catch
            {
                /*Exibir Mensagem de Erro*/
            }
        }

        #endregion
    }
}