<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MovimentoGrid.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.MovimentoGrid" %>
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
            Produto:
        </td>
        <td>
            <gt:ComboBox ID="ProdutoFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetProdutosByDescricao" DataValueField="Id" DataTextField="CategoriaDescricao"
                Width="300" DataBindID='<%# Bind("IdProduto")%>' />
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
    <asp:ListView ID="MovimentosListView" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="DataLabel" runat="server" Text='<%# Eval("Data", "{0:d}") %>' Width="100" />
                </td>
                <td>
                    <asp:Label ID="ProdutoLabel" runat="server" Text='<%# Eval("Produto.Descricao") %>'
                        Width="300" />
                </td>
                <td>
                    <asp:Label ID="FilialLabel" runat="server" Text='<%# Eval("Filial.Nome") %>' Width="200" />
                </td>
                <td>
                    <asp:Label ID="QuantidadeLabel" runat="server" Text='<%# Eval("Quantidade") %>' Width="100" />
                </td>
                <td>
                    <asp:Label ID="SaldoLabel" runat="server" Text='<%# Eval("Saldo") %>' Width="100" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="ObservacoesLabel" runat="server" Text='<%# Eval("Observacoes") %>' />
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
                        Data
                    </th>
                    <th runat="server">
                        Produto
                    </th>
                    <th runat="server">
                        Filial
                    </th>
                    <th runat="server" align="right">
                        Qtde
                    </th>
                    <th runat="server" align="right">
                        Saldo
                    </th>
                </tr>
                <tr>
                    <th runat="server" colspan="5">
                        Observações
                    </th>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
            </td> </tr>
        </LayoutTemplate>
    </asp:ListView>
</p>
