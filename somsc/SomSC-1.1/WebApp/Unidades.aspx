<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Unidades.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Unidades" %>

<%@ Register TagPrefix="gt" TagName="UnidadeGrid" Src="~/Controls/UnidadeGrid.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Unidades</h1>
    <p>
        Um cadastro besta para informar unidades associadas com os produtos. Apesar de besta,
        exclusões aqui impactam seriamente o sistema. Portanto, é melhor deixar quieto.</p>
    <p>
        ATENÇÃO: a exclusão de unidades pode desencadear o fim do mundo: excluindo uma unidade,
        todos os produtos associados são excluídos também. Excluindo os produtos, advinhe
        o que acontece com a movimentação?</p>
    <gt:UnidadeGrid ID="UnidadeGrid" runat="server" />
</asp:Content>
