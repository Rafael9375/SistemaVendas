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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioTO usuario = new UsuarioTO();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuario.DesLogin = txtLogin.Text;
            usuario.Senha = txtSenha.Text;
            var retorno = usuarioDAL.Login(usuario);
            if (retorno != null)
            {
                if (retorno.IdUsuario > 0)
                {
                    Session["usuarioId"] = retorno.IdUsuario;
                    Response.Redirect("Default.aspx");
                }
            }
        }

    }
}
