<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CadastrarVenda.aspx.cs" Inherits="SistemaVendas.CadastrarVenda" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Mascara/configuracao.js"></script>
    <script src="Scripts/Mascara/jquery.mask.js"></script>
    <script src="Scripts/Mascara/jquery.mask.min.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Cadastrar Venda</h2>
    
    <p>
        <asp:Label ID="lblEmpresa" runat="server" Text="Empresa"></asp:Label>
    </p>
    <ajaxToolkit:ComboBox ID="ComboBox1" runat="server" OnLoad="ComboBox1_Load" Enabled="False" Visible="False"></ajaxToolkit:ComboBox>        
    <ajaxToolkit:ComboBox ID="ComboBox2" runat="server">
        <asp:ListItem Selected="True">Selecione a empresa</asp:ListItem>
</ajaxToolkit:ComboBox>
    <p>
        <asp:Label ID="lblValor" runat="server" Text="Valor"></asp:Label>
    </p>
    <asp:TextBox ID="txtValor" CssClass="money" runat="server"></asp:TextBox>
    <p>
        <asp:Label ID="lblData" runat="server" Text="Data da Venda"></asp:Label>
    </p>
    <asp:Calendar ID="cldDataVenda" runat="server" FirstDayOfWeek="Sunday" SelectedDate="02/15/2022 00:51:20"></asp:Calendar>
    <p>
        <asp:Label ID="lblNF" runat="server" Text="Nota Fiscal Emitida"></asp:Label>
    </p>
    <asp:CheckBox ID="chNF" runat="server" /><br><br>
    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
</asp:Content>