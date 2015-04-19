<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProdutoFilter.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.ProdutoFilter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Com.Gt.SomSc.WebApp" Namespace="Com.Gt.SomSc.WebApp.Controls"
    TagPrefix="gt" %>
    
<ajax:CascadingDropDown ID="CategoriasCascading" runat="server" TargetControlID="CategoriaFilterComboBox"
    Category="Categoria" PromptText="Selecione categoria" LoadingText="Aguarde..."
    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetCategorias" />
<ajax:CascadingDropDown ID="ProdutosCascading" runat="server" TargetControlID="ProdutoFilterComboBox"
    ParentControlID="CategoriaFilterComboBox" Category="Produto" PromptText="Selecione produto"
    LoadingText="Aguarde..." ServicePath="~/AutoComplete.asmx" ServiceMethod="GetProdutosForCategoria" />

<tr>
    <td>
        Categoria:
    </td>
    <td>
        <gt:NoValidationDropDownList ID="CategoriaFilterComboBox" runat="server" Width="150" />
    </td>
</tr>
<tr>
    <td>
        Produto:
    </td>
    <td>
        <gt:NoValidationDropDownList ID="ProdutoFilterComboBox" runat="server" Width="300" />
    </td>
</tr>
