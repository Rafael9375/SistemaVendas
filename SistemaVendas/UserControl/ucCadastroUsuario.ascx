<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCadastroUsuario.ascx.cs"
    Inherits="SistemaVendas.Web.UserControl.ucCadastroUsuario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<fieldset class="scheduler-border" style="background-color:white;">
    <legend class="scheduler-border">Cadastro</legend>
    <asp:UpdatePanel ID="updFilters" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-6 col-md-2">
                    <label class="formText">
                        Nome:
                    </label>
                </div>
                <div class="col-xs-6 col-md-3">
                    <asp:TextBox ID="txtNome" runat="server" class="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-sm-6 col-md-1">
                </div>
                <div class="col-sm-6 col-md-2">
                    <label class="formText">
                        CPF:
                    </label>
                </div>
                <div class="col-xs-6 col-md-3">
                    <asp:TextBox ID="txtCpf" runat="server" class="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-md-2">
                    <label class="formText">
                        RG:
                    </label>
                </div>
                <div class="col-xs-6 col-md-3">
                    <asp:TextBox ID="txtRG" runat="server" class="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-sm-6 col-md-1">
                </div>
                <div class="col-sm-6 col-md-2">
                    <label class="formText">
                        Telefone:
                    </label>
                </div>
                <div class="col-xs-6 col-md-3">
                    <asp:TextBox ID="txtTelefone" runat="server" class="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-md-2">
                    <label class="formText">
                        Login:
                    </label>
                </div>
                <div class="col-xs-6 col-md-3">
                    <asp:TextBox ID="txtLogin" runat="server" class="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-sm-6 col-md-1">
                </div>
                <div class="col-sm-6 col-md-2">
                    <label class="formText">
                        Senha:
                    </label>
                </div>
                <div class="col-xs-6 col-md-3">
                    <asp:TextBox ID="txtSenha" runat="server" class="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
            </div>
            <div class="row">
                <div class="col-xs-6 col-md-8">
                    <asp:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
                    <button id="btnVoltar" onclick="$('#btnCloseCadastroUsuario').click()">
                        Voltar</button>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
