<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modal.aspx.cs" Inherits="Com.Gt.SomSc.DynApp.Modal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ct" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ct:ToolkitScriptManager ID="ScriptManager" runat="server">
            <Services>
                <asp:ServiceReference Path="~/AutoComplete.asmx" />
            </Services>
        </ct:ToolkitScriptManager>
        <asp:LinkButton ID="btnShowPopup" runat="server">Produtos</asp:LinkButton>
        <ct:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="inactive"
            OkControlID="btnOk" CancelControlID="btnCancel" TargetControlID="btnShowPopup"
            OnCancelScript="onCancel()" OnOkScript="onOk()" PopupControlID="pnlProdutos">
        </ct:ModalPopupExtender>
        <asp:Panel ID="pnlProdutos" runat="server" CssClass="modalPopup">
            <asp:Label ID="lblProdutos" runat="server" Text="Produtos"></asp:Label>
            <br />
            <asp:Repeater ID="lstProdutos" runat="server">
                <HeaderTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <th runat="server">
                                Codigo
                            </th>
                            <th runat="server">
                                Descricao
                            </th>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("Codigo") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblDescricao" runat="server" Text='<%# Eval("Descricao") %>' />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Button ID="btnOk" runat="server" Text="OK" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </asp:Panel>
    </div>
    <ct:ComboBox ID="cbxxProdutos" runat="server" DataTextField="Descricao" DataValueField="Id"
        AutoCompleteMode="SuggestAppend" />
    <asp:TextBox ID="edtProduto" runat="server" />
    <ct:AutoCompleteExtender ID="autoProdutos" runat="server" TargetControlID="edtProduto"
        ServicePath="~/AutoComplete.asmx" ServiceMethod="GetProdutosByCodigo" MinimumPrefixLength="3"
        EnableCaching="true"  />
    <div>
        Categoria:
        <asp:DropDownList ID="cbxCategorias" runat="server" />
        <br />
        Produto:
        <asp:DropDownList ID="cbxProdutos" runat="server" />
        <ct:CascadingDropDown ID="cddCategorias" runat="server" TargetControlID="cbxCategorias"
            Category="Categoria" PromptText="Selecione categoria" ServicePath="~/AutoComplete.asmx"
            ServiceMethod="GetCategorias" />
            
        <ct:CascadingDropDown ID="cddProdutos" runat="server" TargetControlID="cbxProdutos" ParentControlID="cbxCategorias"
            Category="Produto" PromptText="Selecione produto" ServicePath="~/AutoComplete.asmx"
            ServiceMethod="GetProdutosForCategoria" />
    </div>
    </form>
</body>
</html>
