using SistemaVenda.Core.DAL;
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
    public partial class CadastrarVenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            VendaTO venda = new VendaTO();
            VendaDAL vendaDAL = new VendaDAL();
            if (txtValor.Text == "")
            {
                Response.Write("<script>alert('Informe o valor!')</script>");
            }
            else if (ComboBox2.SelectedValue == "Selecione a empresa")
            {
                Response.Write("<script>alert('Selecione a empresa!')</script>");
            }
            else if (Session["UsuarioId"] == null)
            {
                Response.Write("<script>alert('Necessário fazer o login!')</script>");
            }
            else
            {
                venda.DataVenda = cldDataVenda.SelectedDate;
                venda.EmitidoNF = chNF.Checked;
                venda.IdUsuarioCadastro = Int32.Parse(Session["UsuarioId"].ToString());
                venda.IdEmpresa = Int32.Parse(ComboBox2.Text);
                venda.ValorVenda = decimal.Parse(txtValor.Text);
                try
                {
                    vendaDAL.Insert(venda);
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('Erro no sistema')</script>");
                }
                finally
                {
                    Response.Write("<script>alert('Venda cadastrada!')</script>");
                    txtValor.Text = "";
                    
                    chNF.Checked = false;
                }
            }
        }

        protected void ComboBox1_Load(object sender, EventArgs e)
        {
            EmpresaDAL empresaDAL = new EmpresaDAL();
            EmpresaTO empresaTO = new EmpresaTO();
            var empresas = empresaDAL.GetData(empresaTO);
            foreach (var empresa in empresas)
            {
                var item = new ListItem(empresa.RazaoSocial, empresa.IdEmpresa.ToString());
                if (!ComboBox2.Items.Contains(item))
                {
                    ComboBox2.Items.Add(item);
                }
            }
            var itemInicial = new ListItem("Selecione a empresa", "Selecione a empresa");
        }
    }
}