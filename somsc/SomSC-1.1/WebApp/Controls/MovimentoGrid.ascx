<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MovimentoGrid.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.MovimentoGrid" %>
<%@ Register TagPrefix="gt" TagName="ComboBox" Src="~/Controls/ComboBox.ascx" %>
<%@ Register TagPrefix="gt" TagName="ProdutoFilter" Src="~/Controls/ProdutoFilter.ascx" %>

<table class="grid">
    <tr>
        <th colspan="2">
            Filtro
        </th>
    </tr>
    <gt:ProdutoFilter ID="ProdutoFilter" runat="server" />
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
    <asp:ListView ID="MovimentosListView" runat="server" DataSourceID="MovimentosObjectData">
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
<asp:ObjectDataSource ID="MovimentosObjectData" runat="server" SelectMethod="GetMovimentosByProdutoAndFilial"
    TypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext" OnObjectDisposing="MovimentosObjectData_ObjectDisposing">
    <SelectParameters>
        <asp:ControlParameter ControlID="ProdutoFilter" Name="IdProduto" PropertyName="ProdutoId"
            Type="Int32" />
        <asp:ControlParameter ControlID="FilialFilterComboBox" Name="IdFilial" PropertyName="DataBindID"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
