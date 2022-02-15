<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SistemaVendas.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Login
    </h2>
    <p>
        <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
    </p>
    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
    <br>
    <p>
        <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
    </p>
    <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
    <p>
        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
    </p>
</asp:Content>
