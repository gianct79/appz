<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Fornecedores.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Fornecedores" %>

<%@ Register TagPrefix="gt" TagName="FornecedorGrid" Src="~/Controls/FornecedorGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Fornecedores</h1>
    <p>
        Cadastre aqui os inúmeros fornecedores de equipamentos de SOM da empresa que causam
        pavor na vizinhança. Tum tis tum!</p>
    <gt:FornecedorGrid ID="FornecedorGrid" runat="server" />
</asp:Content>
