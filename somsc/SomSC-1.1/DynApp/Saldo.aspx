<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Saldo.aspx.cs" Inherits="Com.Gt.SomSc.DynApp.Saldo" %>

<%@ Register TagPrefix="uc" Namespace="Com.Gt.SomSc.DynApp" Assembly="Com.Gt.SomSc.DynApp" %>

<%@ Register TagPrefix="uc" TagName="ProdutoTextBox" Src="~/ProdutoTextBox.ascx" %>
<%@ Register TagPrefix="uc" TagName="ComboBox" Src="~/ComboBox.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <uc:PasswordTextBox ID="PasswordTextBox" runat="server" Password=" pass " Text="realpass" Width="200" />

        <uc:ComboBox ID="ProdutoComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
        DataSourceMethod="get_Produtos" DataValueField="Id" DataTextField="Descricao" Width="200" />

        <uc:ProdutoTextBox ID="ProdutoTextBox" runat="server" />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Crypto</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Movimentos</asp:LinkButton>
        <br />
        <asp:ListView ID="ListView1" runat="server" >
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="DataLabel" runat="server" Text='<%# Eval("Data") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DescricaoLabel" runat="server" Text='<%# Eval("Produto.Descricao") %>' />
                    </td>
                    <td>
                        <asp:Label ID="QuantidadeLabel" runat="server" Text='<%# Eval("Quantidade") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SaldoLabel" runat="server" Text='<%# Eval("SaldoString") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            No data was returned.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server">
                                        Data
                                    </th>
                                    <th runat="server">
                                        Produto
                                    </th>
                                    <th runat="server">
                                        Quantidade
                                    </th>
                                    <th runat="server">
                                        Saldo
                                    </th>                                    
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Saldo</asp:LinkButton>
        <br />
        <asp:DataList ID="DataList1" runat="server">
        <HeaderTemplate>
        <table>
        <thead>
        <tr>
        <th>Produto</th>
        <th>Filial</th>
        <th>Saldo</th>
        </tr>
        </thead>
        </table>
        </HeaderTemplate>
        <ItemTemplate>
        <table>
        <tr>
        <td><asp:Label ID="ProdutoLabel" runat="server" Text='<%# Eval("Produto.Descricao") %>' /></td>
        <td><asp:Label ID="FilialLabel" runat="server" Text='<%# Eval("Filial.Nome") %>' /></td>
        <td><asp:Label ID="SaldoLabel" runat="server" Text='<%# Eval("QuantidadeString") %>' /></td>
        </tr>
        </table>
        </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
