<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SaldoGrid.ascx.cs" Inherits="Com.Gt.SomSc.WebApp.Controls.SaldoGrid" %>
<%@ Register TagPrefix="gt" TagName="ComboBox" Src="~/Controls/ComboBox.ascx" %>
<%@ Register TagPrefix="gt" TagName="ProdutoFilter" Src="~/Controls/ProdutoFilter.ascx" %>

<table class="grid">
    <tr>
        <th colspan="2">
            Filtro
        </th>
    </tr>
    <gt:ProdutoFilter ID="ProdutoFilter" runat="server" ShowAll="true" />
    <tr>
        <td>
            Filial:
        </td>
        <td>
            <gt:ComboBox ID="FilialFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetFiliaisByNome" DataValueField="Id" DataTextField="Nome"
                Width="200" DataBindID='<%# Bind("IdFilial")%>' ShowAll="true" />
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
    <asp:ListView ID="SaldosListView" runat="server" DataSourceID="SaldosObjectData">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="ProdutoLabel" runat="server" Text='<%# Eval("Produto.Descricao") %>'
                        Width="300" />
                </td>
                <td>
                    <asp:Label ID="CategoriaLabel" runat="server" Text='<%# Eval("Produto.Categoria.Descricao") %>'
                        Width="150" />
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
                        <asp:LinkButton ID="ProdutoButton" runat="server" CommandName="Sort" CommandArgument="Produto.Descricao"
                            Text="Produto" />
                    </th>
                    <th runat="server">
                        <asp:LinkButton ID="CategoriaButton" runat="server" CommandName="Sort" CommandArgument="Produto.Categoria.Descricao"
                            Text="Categoria" />
                        <br />
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
<asp:ObjectDataSource ID="SaldosObjectData" runat="server" SelectMethod="GetSaldos"
    TypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext" OnObjectDisposing="SaldosObjectData_ObjectDisposing"
    SortParameterName="Sort">
    <SelectParameters>
        <asp:ControlParameter ControlID="ProdutoFilter" Name="IdCategoria" PropertyName="CategoriaId"
            Type="Int32" />
        <asp:ControlParameter ControlID="ProdutoFilter" Name="IdProduto" PropertyName="ProdutoID"
            Type="Int32" />
        <asp:ControlParameter ControlID="FilialFilterComboBox" Name="IdFilial" PropertyName="DataBindID"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
