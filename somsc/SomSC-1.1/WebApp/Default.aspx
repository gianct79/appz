<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Olá,&nbsp;<asp:LoginName ID="LoginName" runat="server" />!</p>
    <p>
        Bem vindo ao site de controle de estoques da SomSC, uma empresa especializada em
        SOM automotivo!</p>
    <p>
        O controle de estoques apresentado aqui é muito simplista:</p>
    <ul>
        <li>em primeiro lugar, configure <a href="Usuarios.aspx">Usuários</a> e <a href="Filiais.aspx">
            Filiais</a>;</li>
        <li>depois, configure cadastros auxiliares para os produtos como <a href="Categorias.aspx">
            Categorias</a>, <a href="Unidades.aspx">Unidades de Medida</a> e <a href="Fornecedores.aspx">
                Fornecedores</a>;</li>
        <li>após completar os cadastros anteriores, crie <a href="Produtos.aspx">Produtos</a>
            para controlar o estoque;</li>
        <li>movimente as quantidades dos produtos através do menu <a href="Ajustes.aspx">Ajustes
            de Estoque</a>;</li>
        <li>visualize a movimentação e confira os saldos com as opções do menu Relatórios.</li>
    </ul>
    <p>
        NOTA: este sistema <i>Web</i> utiliza JavaScript para uma penca de coisas. Portato, certifique-se
        que o suporte a JavaScript do seu navegador esteja habilitado.</p>
    <p>
        As telas possuem um leiaute padrão em formato de grade. O botão
        <img src="Images/edit.png" alt="Editar" />
        edita o registro da linha e você pode confirmar suas alterações com
        <img src="Images/confirm.png" alt="Confirmar" />.</p>
    <p>
        Para criar um novo registro, clique em
        <img src="Images/create.png" alt="Criar" />. Confirme com
        <img src="Images/confirm.png" alt="Confirmar" />
        ou cancele com
        <img src="Images/undo.png" alt="Cancelar" />.</p>
    <p>
        Exclusões são tratadas com o botão
        <img src="Images/delete.png" alt="Excluir" />. Muita atenção ao excluir registros
        dos cadastros de Usuários, Produtos, Unidades de Medida e Fornecedores, pois os mesmos possuem
        associações e exclusões produzem um efeito cascata que se propaga por todo o sistema.</p>
    <p>
        Então, o que você está esperando? Clique logo em uma das opções no menu à esquerda
        e controle TUDO!</p>
    <p>
        &nbsp;</p>
</asp:Content>
