<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AjusteGrid.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.AjusteGrid" %>
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
            Data:
        </td>
        <td>
            <asp:TextBox ID="DataFilterTextBox" runat="server" Width="100" />
            <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="DataFilterTextBox"
                Format="dd/MM/yyyy" />
            <asp:CompareValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma data dd/mm/aaaa."
                ValidationGroup="GroupB" Type="Date" Operator="DataTypeCheck" ControlToValidate="DataFilterTextBox" />
        </td>
    </tr>
    <tr>
        <td>
            Produto:
        </td>
        <td>
            <gt:ComboBox ID="ProdutoFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetProdutosByDescricao" DataValueField="Id" DataTextField="CategoriaDescricao"
                Width="250" DataBindID='<%# Bind("IdProduto")%>' ShowAll="true" />
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
            Usuário:
        </td>
        <td>
            <gt:ComboBox ID="UsuarioFilterComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                DataSourceMethod="GetUsuariosByNome" DataValueField="Id" DataTextField="Nome" Width="150"
                DataBindID='<%# Bind("IdUsuario")%>' ShowAll="true" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td align="right">
            <asp:Button ID="FilterButton" runat="server" Text="Aplicar" ValidationGroup="GroupB"
                CssClass="button" />
        </td>
    </tr>
</table>
<p>
    <asp:ListView ID="AjustesListView" runat="server" DataKeyNames="Id" DataSourceID="AjustesLinqData"
        InsertItemPosition="FirstItem" OnItemInserting="AjustesListView_ItemInserting"
        OnDataBound="AjustesListView_DataBound" OnItemCommand="AjustesListView_ItemCommand">
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
                    <asp:Label ID="UsuarioLabel" runat="server" Text='<%# Eval("Usuario.Nome") %>' Width="150" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="ObservacoesLabel" runat="server" Text='<%# Eval("Observacoes") %>' />
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
            <tr>
                <td>
                    <asp:TextBox ID="DataTextBox" runat="server" Text='<%# Bind("Data", "{0:d}") %>'
                        Width="100" />
                    <ajax:CalendarExtender ID="DataCalendarExtender" runat="server" TargetControlID="DataTextBox"
                        Format="dd/MM/yyyy" />
                    <asp:CompareValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma data dd/mm/aaaa."
                        ValidationGroup="GroupA" Type="Date" Operator="DataTypeCheck" ControlToValidate="DataTextBox" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma data dd/mm/aaaa."
                        ValidationGroup="GroupA" ControlToValidate="DataTextBox" />
                </td>
                <td>
                    <gt:ComboBox ID="ProdutoComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetProdutosByDescricao" DataValueField="Id" DataTextField="CategoriaDescricao"
                        Width="300" DataBindID='<%# Bind("IdProduto")%>' />
                </td>
                <td>
                    <gt:ComboBox ID="FilialComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetFiliaisByNome" DataValueField="Id" DataTextField="Nome" Width="200"
                        DataBindID='<%# Bind("IdFilial")%>' />
                </td>
                <td>
                    <asp:TextBox ID="QuantidadeTextBox" runat="server" Text='<%# Bind("Quantidade") %>'
                        Width="100" />
                    <asp:CompareValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe a quantidade."
                        ValidationGroup="GroupA" Type="Double" Operator="DataTypeCheck" ControlToValidate="QuantidadeTextBox" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe a quantidade."
                        ValidationGroup="GroupA" ControlToValidate="QuantidadeTextBox" />
                </td>
                <td>
                    <asp:LoginName ID="LoginName" runat="server" Width="150" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="ObservacoesTextBox" runat="server" Width="600" TextMode="MultiLine"
                        Text='<%# Bind("Observacoes") %>' />
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
                        <asp:LinkButton ID="DataButton" runat="server" CommandName="Sort" CommandArgument="Data"
                            Text="Data" />
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
                        Qtde
                    </th>
                    <th runat="server">
                        <asp:LinkButton ID="UsuarioButton" runat="server" CommandName="Sort" CommandArgument="Usuario.Nome"
                            Text="Usuário" />
                    </th>
                </tr>
                <tr runat="server">
                    <th runat="server" colspan="5">
                        Observações
                    </th>
                </tr>
                <tr id="itemPlaceholder" runat="server">
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:TextBox ID="DataTextBox" runat="server" Text='<%# Bind("Data", "{0:d}") %>'
                        Width="100" />
                    <ajax:CalendarExtender ID="DataCalendarExtender" runat="server" TargetControlID="DataTextBox"
                        Format="dd/MM/yyyy" />
                    <asp:CompareValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma data dd/mm/aaaa."
                        ValidationGroup="GroupA" Type="Date" Operator="DataTypeCheck" ControlToValidate="DataTextBox" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma data dd/mm/aaaa."
                        ValidationGroup="GroupA" ControlToValidate="DataTextBox" />
                </td>
                <td>
                    <gt:ComboBox ID="ProdutoComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetProdutosByDescricao" DataValueField="Id" DataTextField="CategoriaDescricao"
                        Width="300" DataBindID='<%# Bind("IdProduto")%>' />
                </td>
                <td>
                    <gt:ComboBox ID="FilialComboBox" runat="server" DataSourceTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
                        DataSourceMethod="GetFiliaisByNome" DataValueField="Id" DataTextField="Nome" Width="200"
                        DataBindID='<%# Bind("IdFilial")%>' />
                </td>
                <td>
                    <asp:TextBox ID="QuantidadeTextBox" runat="server" Text='<%# Bind("Quantidade") %>'
                        Width="100" />
                    <asp:CompareValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe a quantidade."
                        ValidationGroup="GroupA" Type="Double" Operator="DataTypeCheck" ControlToValidate="QuantidadeTextBox" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe a quantidade."
                        ValidationGroup="GroupA" ControlToValidate="QuantidadeTextBox" />
                </td>
                <td>
                    <asp:Label ID="UsuarioTextBox" runat="server" Text='<%# Eval("Usuario.Nome") %>'
                        Width="150" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="ObservacoesTextBox" runat="server" Width="600" TextMode="MultiLine"
                        Text='<%# Bind("Observacoes") %>' />
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
<asp:LinqDataSource ID="AjustesLinqData" runat="server" ContextTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
    EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Movimentos"
    OrderBy="Data" OnLoad="AjustesLinqData_Load">
</asp:LinqDataSource>
