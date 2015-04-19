<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProdutoGrid.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.ProdutoGrid" %>
<%@ Register TagPrefix="gt" TagName="ComboBox" Src="~/Controls/ComboBox.ascx" %>
<table class="grid">
    <tr>
        <th colspan="2">
            Filtro
        </th>
    </tr>
    <tr>
        <td>
            Descrição:
        </td>
        <td>
            <asp:TextBox ID="DescricaoFilterTextBox" runat="server" Text="" Width="300" />
        </td>
    </tr>
    <tr>
        <td>
            Categoria:
        </td>
        <td>
            <gt:ComboBox ID="CategoriaFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetCategoriasByDescricao" DataValueField="Id" DataTextField="Descricao"
                Width="150" ShowAll="true" />
        </td>
    </tr>
    <tr>
        <td>
            Fornecedor:
        </td>
        <td>
            <gt:ComboBox ID="FornecedorFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetFornecedoresByRazao" DataValueField="Id" DataTextField="RazaoSocial"
                Width="150" ShowAll="true" />
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
    <asp:ListView ID="ProdutosListView" runat="server" DataKeyNames="Id" DataSourceID="ProdutosLinqData"
        InsertItemPosition="FirstItem" OnItemCommand="ProdutosListView_ItemCommand" OnDataBound="ProdutosListView_DataBound">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="DescricaoLabel" runat="server" Text='<%# Eval("Descricao") %>' Width="300" />
                </td>
                <td>
                    <asp:Label ID="CategoriaLabel" runat="server" Text='<%# Eval("Categoria.Descricao") %>'
                        Width="150" />
                </td>
                <td>
                    <asp:Label ID="FornecedorLabel" runat="server" Text='<%# Eval("Fornecedor.RazaoSocial") %>'
                        Width="200" />
                </td>
                <td>
                    <asp:Label ID="CriticoLabel" runat="server" Text='<%# Eval("Critico") %>' Width="50"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="UnidadeLabel" runat="server" Text='<%# Eval("Unidade.Descricao") %>'
                        Width="100" />
                </td>
                <td>
                    <asp:ImageButton ID="EditButton" runat="server" CommandName="Edit" AlternateText="Edit"
                        ImageUrl="~/Images/edit.png" />
                    <asp:ImageButton ID="DeleteButton" runat="server" CommandName="Delete" AlternateText="Excluir"
                        ImageUrl="~/Images/delete.png" />
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
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:TextBox ID="DescricaoTextBox" runat="server" Text='<%# Bind("Descricao") %>'
                        Width="300" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma descrição."
                        ValidationGroup="GroupA" ControlToValidate="DescricaoTextBox" />
                </td>
                <td>
                    <gt:ComboBox ID="CategoriaComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetCategoriasByDescricao" DataValueField="Id" DataTextField="Descricao"
                        Width="150" DataBindID='<%# Bind("IdCategoria")%>' />
                </td>
                <td>
                    <gt:ComboBox ID="FornecedorComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetFornecedoresByRazao" DataValueField="Id" DataTextField="RazaoSocial"
                        Width="200" DataBindID='<%# Bind("IdFornecedor")%>' />
                </td>
                <td>
                    <asp:TextBox ID="CriticoTextBox" runat="server" Text='<%# Bind("Critico") %>' Width="100" />
                    <asp:CompareValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe o estoque mínimo."
                        ValidationGroup="GroupA" Type="Double" Operator="DataTypeCheck" ControlToValidate="CriticoTextBox" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe o estoque mínimo."
                        ValidationGroup="GroupA" ControlToValidate="CriticoTextBox" />
                </td>
                <td>
                    <gt:ComboBox ID="UnidadeComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetUnidadesByDescricao" DataValueField="Id" DataTextField="Descricao"
                        Width="100" DataBindID='<%# Bind("IdUnidade")%>' />
                </td>
                <td>
                    <asp:ImageButton ID="InsertButton" runat="server" CommandName="Insert" AlternateText="Insert"
                        ImageUrl="~/Images/create.png" ValidationGroup="GroupA" />
                    <asp:ImageButton ID="CancelButton" runat="server" CommandName="Cancel" AlternateText="Clear"
                        ImageUrl="~/Images/undo.png" />
                </td>
            </tr>
        </InsertItemTemplate>
        <LayoutTemplate>
            <table id="itemPlaceholderContainer" runat="server" class="grid">
                <tr runat="server" style="">
                    <th runat="server">
                        <asp:LinkButton ID="DescricaoButton" runat="server" CommandName="Sort" CommandArgument="Descricao"
                            Text="Descrição" />
                    </th>
                    <th runat="server">
                        <asp:LinkButton ID="CategoriaButton" runat="server" CommandName="Sort" CommandArgument="Categoria.Descricao"
                            Text="Categoria" />
                    </th>
                    <th runat="server">
                        <asp:LinkButton ID="FornecedorButton" runat="server" CommandName="Sort" CommandArgument="Fornecedor.RazaoSocial"
                            Text="Fornecedor" />
                    </th>
                    <th runat="server" align="right">
                        Mínimo
                    </th>
                    <th runat="server">
                        Unidade
                    </th>
                    <th runat="server">
                    </th>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:TextBox ID="DescricaoTextBox" runat="server" Text='<%# Bind("Descricao") %>'
                        Width="300" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma descrição."
                        ValidationGroup="GroupA" ControlToValidate="DescricaoTextBox" />
                </td>
                <td>
                    <gt:ComboBox ID="CategoriaComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetCategoriasByDescricao" DataValueField="Id" DataTextField="Descricao"
                        Width="150" DataBindID='<%# Bind("IdCategoria")%>' />
                </td>
                <td>
                    <gt:ComboBox ID="FornecedorComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetFornecedoresByRazao" DataValueField="Id" DataTextField="RazaoSocial"
                        Width="200" DataBindID='<%# Bind("IdFornecedor")%>' />
                </td>
                <td>
                    <asp:TextBox ID="CriticoTextBox" runat="server" Text='<%# Bind("Critico") %>' Width="100" />
                    <asp:CompareValidator ID="CompareValidator2" runat="server" SetFocusOnError="true"
                        Text="*" ErrorMessage="Informe o estoque mínimo." ValidationGroup="GroupA" Type="Double"
                        Operator="DataTypeCheck" ControlToValidate="CriticoTextBox" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe o estoque mínimo."
                        ValidationGroup="GroupA" ControlToValidate="CriticoTextBox" />
                </td>
                <td>
                    <gt:ComboBox ID="UnidadeComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetUnidadesByDescricao" DataValueField="Id" DataTextField="Descricao"
                        Width="100" DataBindID='<%# Bind("IdUnidade")%>' />
                </td>
                <td>
                    <asp:ImageButton ID="UpdateButton" runat="server" CommandName="Update" AlternateText="Update"
                        ImageUrl="~/Images/confirm.png" ValidationGroup="GroupA" />
                    <asp:ImageButton ID="CancelButton" runat="server" CommandName="Cancel" AlternateText="Cancel"
                        ImageUrl="~/Images/undo.png" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</p>
<asp:LinqDataSource ID="ProdutosLinqData" runat="server" ContextTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
    EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Produtos"
    OrderBy="Descricao" OnLoad="ProdutosLinqData_Load">
</asp:LinqDataSource>
