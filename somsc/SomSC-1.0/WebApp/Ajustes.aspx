<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Ajustes.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Ajustes" %>

<%@ Register TagPrefix="gt" TagName="AjusteGrid" Src="~/Controls/AjusteGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Ajustes de Estoques</h1>
    <p>
        A função mais importante do sistema. Controle aqui a sua movimentaçao diária, informando
        os produtos e quantidades. O movimento está sempre associado com o usuário logado.</p>
    <p>
        Os movimentos estão filtrados pela data atual. Para visualizar TUDO, deixe o campo
        data do filtro em branco. Provavelmente ficará lento, uma vez que o sistema irá
        recuperar toda a movimentação desde o início dos tempos.</p>
    <gt:AjusteGrid ID="AjusteGrid" runat="server" />
</asp:Content>
