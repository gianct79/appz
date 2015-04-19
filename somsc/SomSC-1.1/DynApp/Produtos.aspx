<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Com.Gt.SomSc.DynApp.Produtos" %>

<%@ Register TagPrefix="uc" TagName="ComboBox" Src="~/ComboBox.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::: Produtos :::</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Produtos">
    </asp:LinqDataSource>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="LinqDataSource1"
        InsertItemPosition="LastItem">
        <ItemTemplate>
            <tr >
                <td>
                    <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" Text="Excluir"/>
                </td>
                <td>
                    <asp:LinkButton ID="CodigoButton" runat="server" CommandName="Edit" Text='<%# Eval("Codigo")%>' />
                </td>
                <td>
                    <asp:Label ID="DescricaoLabel" runat="server" Text='<%# Eval("Descricao") %>' />
                </td>
                <td>
                    <asp:Label ID="PrecoCustoLabel" runat="server" Text='<%# Eval("PrecoCusto") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="AtivoCheckBox" runat="server" Checked='<%# Eval("Ativo") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="CategoriaLabel" runat="server" Text='<%# Eval("Categoria.Descricao") %>' />
                </td>
                <td>
                    <asp:Label ID="UnidadeLabel" runat="server" Text='<%# Eval("Unidade.Simbolo") %>' />
                </td>
                <td>
                    <asp:Label ID="FornecedorLabel" runat="server" Text='<%# Eval("Fornecedor.RazaoSocial") %>' />
                </td>
                <td>
                    <asp:Label ID="SaldoLabel" runat="server" Text='<%# Eval("Saldo") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" >
                <tr>
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr >
                <td>
                    <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" Text="Incluir" />
                </td>
                <td>
                    <asp:TextBox ID="CodigoTextBox" runat="server" Text='<%# Bind("Codigo") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DescricaoTextBox" runat="server" Text='<%# Bind("Descricao") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PrecoCustoTextBox" runat="server" Text='<%# Bind("PrecoCusto") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="AtivoCheckBox" runat="server" Checked='<%# Bind("Ativo") %>' />
                </td>
                <td>
                    <uc:ComboBox ID="CategoriaComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="get_Categorias" DataValueField="Id" DataTextField="Descricao"
                        Width="200" DataBindID='<%# Bind("IdCategoria")%>' />
                </td>
                <td>
                    <uc:ComboBox ID="UnidadeComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="get_Unidades" DataValueField="Id" DataTextField="Descricao"
                        Width="200" DataBindID='<%# Bind("IdUnidade")%>' />
                </td>
                <td>
                    <uc:ComboBox ID="FornecedorComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="get_Fornecedores" DataValueField="Id" DataTextField="RazaoSocial"
                        Width="200" DataBindID='<%# Bind("IdFornecedor")%>' />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </InsertItemTemplate>
        <LayoutTemplate>
            <table id="itemPlaceholderContainer" runat="server">
                <tr runat="server" >
                    <th runat="server">
                    </th>
                    <th runat="server">
                        Codigo
                    </th>
                    <th runat="server">
                        Descricao
                    </th>
                    <th runat="server">
                        PrecoCusto
                    </th>
                    <th runat="server">
                        Ativo
                    </th>
                    <th runat="server">
                        Categoria
                    </th>
                    <th runat="server">
                        Unidade
                    </th>
                    <th id="Th1" runat="server">
                        Fornecedor
                    </th>
                    <th runat="server">
                        Saldo
                    </th>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Salvar" />
                </td>
                <td>
                    <asp:TextBox ID="CodigoTextBox" runat="server" Text='<%# Bind("Codigo") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must provide a Product Code."
                        ControlToValidate="CodigoTextBox">
                            *</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="DescricaoTextBox" runat="server" Text='<%# Bind("Descricao") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PrecoCustoTextBox" runat="server" Text='<%# Bind("PrecoCusto") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="AtivoCheckBox" runat="server" Checked='<%# Bind("Ativo") %>' />
                </td>
                <td>
                    <uc:ComboBox ID="CategoriaComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="get_Categorias" DataValueField="Id" DataTextField="Descricao"
                        Width="200" DataBindID='<%# Bind("IdCategoria")%>' />
                </td>
                <td>
                    <uc:ComboBox ID="UnidadeComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="get_Unidades" DataValueField="Id" DataTextField="Descricao"
                        Width="200" DataBindID='<%# Bind("IdUnidade")%>' />
                </td>
                <td>
                    <uc:ComboBox ID="FornecedorComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="get_Fornecedores" DataValueField="Id" DataTextField="RazaoSocial"
                        Width="200" DataBindID='<%# Bind("IdFornecedor")%>' />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>
