<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsuarioGrid.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.UsuarioGrid" %>
<%@ Register TagPrefix="gt" Namespace="Com.Gt.SomSc.WebApp.Controls" Assembly="Com.Gt.SomSc.WebApp" %>
<p>
    <asp:ListView ID="UsuariosListView" runat="server" DataKeyNames="Id" DataSourceID="UsuariosLinqData"
        InsertItemPosition="LastItem" OnItemInserting="UsuariosListView_ItemInserting"
        OnItemUpdating="UsuariosListView_ItemUpdating" OnItemCommand="UsuariosListView_ItemCommand">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' Width="250" />
                </td>
                <td>
                    <asp:Label ID="ApelidoLabel" runat="server" Text='<%# Eval("Apelido") %>' Width="150" />
                </td>
                <td>
                    <asp:Label ID="SenhaLabel" runat="server" Text="******" />
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
                    <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' Width="250" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe um nome."
                        ValidationGroup="GroupA" ControlToValidate="NomeTextBox" />
                </td>
                <td>
                    <asp:TextBox ID="ApelidoTextBox" runat="server" Text='<%# Bind("Apelido") %>' Width="150" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe um apelido."
                        ValidationGroup="GroupA" ControlToValidate="ApelidoTextBox" />
                </td>
                <td>
                    <asp:TextBox ID="SenhaTextBox" runat="server" TextMode="Password" Text='<%# Bind("SenhaPlain") %>' />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe uma senha."
                        ValidationGroup="GroupA" ControlToValidate="SenhaTextBox" />
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
                <tr runat="server">
                    <th runat="server">
                        <asp:LinkButton ID="NomeButton" runat="server" CommandName="Sort" CommandArgument="Nome"
                            Text="Nome" />
                    </th>
                    <th runat="server">
                        <asp:LinkButton ID="ApelidoButton" runat="server" CommandName="Sort" CommandArgument="Apelido"
                            Text="Apelido" />
                    </th>
                    <th runat="server">
                        Senha
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
                    <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' Width="250" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe um nome."
                        ValidationGroup="GroupA" ControlToValidate="NomeTextBox" />
                </td>
                <td>
                    <asp:TextBox ID="ApelidoTextBox" runat="server" Text='<%# Bind("Apelido") %>' Width="150" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe um apelido."
                        ValidationGroup="GroupA" ControlToValidate="ApelidoTextBox" />
                </td>
                <td>
                    <asp:TextBox ID="SenhaTextBox" runat="server" TextMode="Password" Text='<%# Bind("SenhaPlain") %>' />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe a senha."
                        ValidationGroup="GroupA" ControlToValidate="SenhaTextBox" />
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
<asp:LinqDataSource ID="UsuariosLinqData" runat="server" ContextTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
    EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Usuarios"
    OnDeleting="UsuariosLinqData_Deleting">
</asp:LinqDataSource>
