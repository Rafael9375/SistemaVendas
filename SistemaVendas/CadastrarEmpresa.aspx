<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CadastrarEmpresa.aspx.cs" Inherits="SistemaVendas.CadastrarEmpresa" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <p>
        <asp:Label ID="lblRazaoSocial" runat="server" Text="Razão Social"></asp:Label>
    </p>
    <asp:TextBox ID="txtRazaoSocial" runat="server"></asp:TextBox>
    <p>
        <asp:Label ID="lblCNPJ" runat="server" Text="CNPJ"></asp:Label>
    </p>
    <asp:TextBox ID="txtCNPJ" runat="server"></asp:TextBox>
    <p>
        <asp:Label ID="lblEndereco" runat="server" Text="Endereço"></asp:Label>
    </p>
    <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
    <p>
        <asp:Label ID="lblTelefone" runat="server" Text="Telefone"></asp:Label>
    </p>
    <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox><br><br>
    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
    <asp:UpdatePanel ID="updGrid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlEmpresa" runat="server">
                <fieldset class="scheduler-border">
                    <legend class="scheduler-border">Resultados da Busca</legend>
                    <div class="row">
                        <div class="divGridView table-responsive">
                            <asp:GridView ID="gdvEmpresa" runat="server" AutoGenerateColumns="false" >
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Razão Social
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRazao" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Usuário
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            CNPJ
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCNPJ" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Endereco
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndereco" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Telefone
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTelefone" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtDetalhes" runat="server" ImageUrl="~/Image/lupa.png" Width="20px"
                                                 />
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
</asp:Content>