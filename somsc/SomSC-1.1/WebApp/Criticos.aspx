<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Criticos.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Criticos" %>

<%@ Register TagPrefix="gt" TagName="CriticoGrid" Src="~/Controls/CriticoGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Estoque Crítico</h1>
    <p>
        Hu! Aqui são exibidos os produtos cujo estoque mínimo foi atingido, o que é muito
        perigoso. Não perca tempo: ligue já para o fornecedor associado e garanta produtos
        para pronta entrega!</p>
    <gt:CriticoGrid ID="CriticoGrid" runat="server" />
</asp:Content>
