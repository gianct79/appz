<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Saldos.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Saldos" %>

<%@ Register TagPrefix="gt" TagName="SaldoGrid" Src="~/Controls/SaldoGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Saldos</h1>
    <p>
        Um relatório da situação geral do estoque. Se muitas informações estão sendo retornadas,
        filtre-as por categoria, produto e filial se desejar, e não deixe o estoque acabar!</p>
    <gt:SaldoGrid ID="SaldoGrid" runat="server" />
</asp:Content>
