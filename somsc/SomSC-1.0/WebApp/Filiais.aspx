<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Filiais.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Filiais" %>

<%@ Register TagPrefix="gt" TagName="FilialGrid" Src="~/Controls/FilialGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Filiais</h1>
    <p>
        Gerencie aqui as filiais existentes na empresa.</p>
    <p>
        ATENÇÃO: ao excluir uma filial, TODOS os movimentos associados à mesma serão perdidos!</p>
    <gt:FilialGrid ID="FilialGrid" runat="server" />
</asp:Content>
