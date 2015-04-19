<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SaldoGrid.ascx.cs" Inherits="Com.Gt.SomSc.WebApp.Controls.SaldoGrid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="gt" TagName="ComboBox" Src="~/Controls/ComboBox.ascx" %>
<table class="grid">
    <tr>
        <th colspan="2">
            Filtro
        </th>
    </tr>
    <tr>
        <td>
            Produto:
        </td>
        <td>
            <gt:ComboBox ID="ProdutoFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetProdutosByDescricao" DataValueField="Id" DataTextField="CategoriaDescricao"
                Width="300" DataBindID='<%# Bind("IdProduto")%>' ShowAll="true" />
        </td>
    </tr>
    <tr>
        <td>
            Filial:
        </td>
        <td>
            <gt:ComboBox ID="FilialFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetFiliaisByNome" DataValueField="Id" DataTextField="Nome" Width="200"
                DataBindID='<%# Bind("IdFilial")%>' ShowAll="true" />
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
    <asp:ListView ID="SaldosListView" runat="server" OnSorting="SaldosListView_Sorting"
        OnLoad="SaldosListView_Load">
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
                    <asp:Label ID="FilialLabel" runat="server" Text='<%# Eval("Filial.Nome") %>' Width="200" />
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
                        <asp:LinkButton ID="FilialButton" runat="server" CommandName="Sort" CommandArgument="Filial.Nome"
                            Text="Filial" />
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
