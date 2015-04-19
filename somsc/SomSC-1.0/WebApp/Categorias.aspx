<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Categorias.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Categorias" %>

<%@ Register TagPrefix="gt" TagName="CategoriaGrid" Src="~/Controls/CategoriaGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Categorias</h1>
    <p>
        Neste cadastro encontram-se as categorias de produtos. É útil durante a localização
        dos produtos nos movimentos e demais funcionalidades do sistema.</p>
    <gt:CategoriaGrid ID="CategoriaGrid" runat="server" />
</asp:Content>
