<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Produtos.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Produtos" %>

<%@ Register TagPrefix="gt" TagName="ProdutoGrid" Src="~/Controls/ProdutoGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Produtos</h1>
    <p>
        SIM, o cadastro mais legal do sistema. Produtos para estourar tímpanos e disparar
        alarmes ao redor do mundo inteiro. O que você está esperando? Cadastre logo!</p>
    <p>
        Informe o estoque mínimo para auxiliá-lo na reposição dos estoques.</p>
    <p>
        CUIDADO: ao excluir um produto, toda a movimentação associada vai pro beleléu também!</p>
    <gt:ProdutoGrid ID="ProdutoGrid" runat="server" />
</asp:Content>
