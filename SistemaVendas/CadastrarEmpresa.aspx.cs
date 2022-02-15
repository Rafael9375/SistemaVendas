using SistemaVendas.Core.DAL;
using SistemaVendas.Core.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaVendas
{
    public partial class CadastrarEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            EmpresaTO empresaTO = new EmpresaTO();
            EmpresaDAL empresaDAL = new EmpresaDAL();
            empresaTO.CNPJ = txtCNPJ.Text;
            empresaTO.RazaoSocial = txtRazaoSocial.Text;
            empresaTO.Endereco = txtEndereco.Text;
            empresaTO.Telefone = txtTelefone.Text;
            if (Session["IdUsuario"] != null)
            {
                empresaTO.IdUsuarioCadastro = Int32.Parse(Session["IdUsuario"].ToString());
            }
            empresaDAL.Insert(empresaTO);
        }
    }
}