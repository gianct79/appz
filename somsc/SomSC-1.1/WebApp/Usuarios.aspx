<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Usuarios" %>

<%@ Register TagPrefix="gt" TagName="UsuarioGrid" Src="~/Controls/UsuarioGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Usuários</h1>
    <p>
        Aqui você informa todos os pangarés que vão movimentar o estoque da sua empresa.
        Toda a movimentação tem um usuário associado (que é o usuário logado no momento).
        Isso auxilia na hora de apontar e punir a pessoa que fez uma movimentação torta.</p>
    <p>
        ATENÇÃO: exclua um usuário e veja o que acontece com os movimentos de estoque. Melhor
        não, não é mesmo?</p>
    <gt:UsuarioGrid ID="UsuarioGrid" runat="server" />
</asp:Content>
