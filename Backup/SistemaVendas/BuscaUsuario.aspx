<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BuscaUsuario.aspx.cs" Inherits="SistemaVendas.Web.BuscaUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="UserControl/ucCadastroUsuario.ascx" TagName="ucCadastroUsuario"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="title">
        Busca de Usuários
    </div>
    <fieldset class="scheduler-border">
        <legend class="scheduler-border">Filtros de Busca</legend>
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
                    <div class="col-xs-6 col-md-6">
                        <asp:Button ID="btnBuscar" runat="server"  Text="Buscar" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnNovo" runat="server" class="btn btn-vexia permissionRequest" Text="Novo" OnClick="BtnNovo_Click" />
                        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                    </div>
                </div>
                <div class="row">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <asp:UpdatePanel ID="updGrid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlUsuario" runat="server">
                <fieldset class="scheduler-border">
                    <legend class="scheduler-border">Resultados da Busca</legend>
                    <div class="row">
                        <div class="divGridView table-responsive">
                            <asp:GridView ID="gdvUsuario" runat="server" AutoGenerateColumns="false" OnRowDataBound="gdvUsuario_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Nome
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNome" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Login
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLogin" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            CPF
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCPF" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtDetalhes" runat="server" ImageUrl="~/Image/lupa.png" Width="20px"
                                                OnClick="ibtDetalhes_Click" />
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" CssClass="cellDetalhes" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--#### MODAL CADASTRO ####--%>
    <asp:Panel ID="pnlCadastroUsuario" runat="server" Style="display: none; width: 900px;">
        <asp:Button ID="BtnNovoHidden" runat="server" class="btn btn-vexia" Text="Novo" Style="display: none;" />
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" id="btnCloseCadastroUsuario" class="close" data-dismiss="modal"
                    aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">
                    Cadastro de Usuários</h4>
            </div>
            <div class="modal-body">
                <uc2:ucCadastroUsuario ID="ucCadastroUsuario" runat="server" />
            </div>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mpeCadastroUsuario" runat="server" PopupControlID="pnlCadastroUsuario"
        TargetControlID="BtnNovoHidden" CancelControlID="btnCloseCadastroUsuario" BackgroundCssClass="modalBackground"
        Y="0">
        <Animations>
            <OnShown>
                <Parallel AnimationTarget="pnlCadastroUsuario" Duration="0.3" Fps="25">
                    <FadeIn Duration="0.5" Fps="40" />
                    <Move Horizontal="0" Vertical="30"></Move>
                </Parallel>
            </OnShown>
            <OnHiding>
                <Parallel AnimationTarget="pnlCadastroUsuario" Duration="0.3" Fps="25">
                    <FadeOut Duration="0.5" Fps="40" />
                    <Move Horizontal="0" Vertical="-30"></Move>
                </Parallel>
            </OnHiding>
        </Animations>
    </ajaxToolkit:ModalPopupExtender>
    <%--#### MODAL CADASTRO ####--%>
</asp:Content>
