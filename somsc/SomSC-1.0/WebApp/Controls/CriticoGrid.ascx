<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CriticoGrid.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.CriticoGrid" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<%@ Register TagPrefix="gt" TagName="ComboBox" Src="~/Controls/ComboBox.ascx" %>
<table class="grid">
    <tr>
        <th colspan="2">
            Filtro
        </th>
    </tr>
    <tr>
        <td>
            Categoria:
        </td>
        <td>
            <gt:ComboBox ID="CategoriaFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetCategoriasByDescricao" DataValueField="Id" DataTextField="Descricao"
                Width="150" DataBindID='<%# Bind("Id")%>' ShowAll="true" />
        </td>
    </tr>
    <tr>
        <td>
            Fornecedor:
        </td>
        <td>
            <gt:ComboBox ID="FornecedorFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetFornecedoresByRazao" DataValueField="Id" DataTextField="RazaoSocial"
                Width="150" DataBindID='<%# Bind("Id")%>' ShowAll="true" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td align="right">
            <asp:Button ID="FilterButton" runat="server" Text="Aplicar" CssClass="button" />
        </td>
    </tr>
</table>
<p>
    <asp:ListView ID="CriticosListView" runat="server" OnSorting="CriticosListView_Sorting"
        OnLoad="CriticosListView_Load">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="CodigoLabel" runat="server" Text='<%# Eval("Produto.Codigo") %>' Width="100" />
                </td>
                <td>
                    <asp:Label ID="ProdutoLabel" runat="server" Text='<%# Eval("Produto.Descricao") %>'
                        Width="300" />
                </td>
                <td>
                    <asp:Label ID="FornecedorLabel" runat="server" Text='<%# Eval("Produto.Fornecedor.RazaoSocial") %>'
                        Width="250" />
                </td>
                <td>
                    <asp:Label ID="CriticoLabel" runat="server" Text='<%# Eval("Produto.Critico") %>'
                        Width="100" />
                </td>
                <td>
                    <asp:Label ID="SaldoLabel" runat="server" Text='<%# Eval("Qtde") %>' Width="100" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <table id="emptyPlaceholderContainer" runat="server" class="grid">
                <tr>
                    <th>
                        Sem dados
                    </th>
                </tr>
                <tr>
                    <td>
                        Não existem dados a serem exibidos.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <table id="itemPlaceholderContainer" runat="server" class="grid">
                <tr runat="server" style="">
                    <th runat="server">
                        <asp:LinkButton ID="CodigoButton" runat="server" CommandName="Sort" CommandArgument="Produto.Codigo"
                            Text="Código" />
                        <br />
                    </th>
                    <th runat="server">
                        <asp:LinkButton ID="ProdutoButton" runat="server" CommandName="Sort" CommandArgument="Produto.Descricao"
                            Text="Produto" />
                    </th>
                    <th runat="server">
                        <asp:LinkButton ID="FornecedorButton" runat="server" CommandName="Sort" CommandArgument="Produto.Fornecedor.RazaoSocial"
                            Text="Fornecedor" />
                    </th>
                    <th runat="server" align="right">
                        <asp:LinkButton ID="CriticoButton" runat="server" CommandName="Sort" CommandArgument="Produto.Critico"
                            Text="Mínimo" />
                    </th>
                    <th runat="server" align="right">
                        <asp:LinkButton ID="SaldoButton" runat="server" CommandName="Sort" CommandArgument="Qtde"
                            Text="Saldo" />
                    </th>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</p>
