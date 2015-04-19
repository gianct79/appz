<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Movimentos.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Movimentos" %>

<%@ Register TagPrefix="gt" TagName="MovimentoGrid" Src="~/Controls/MovimentoGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Movimentos</h1>
    <p>
        Ah, os movimentos do estoque! Aqui você acompanha a evolução do estoque ao longo
        do tempo. Uma útil coluna Saldo é exibida para demonstrar o estoque atual num determinado
        momento.</p>
    <p>
        Utilize o filtro abaixo para definir o produto e a filial que deseja visualizar.</p>
    <gt:MovimentoGrid ID="MovimentoGrid" runat="server" />
</asp:Content>
