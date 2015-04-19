<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilialGrid.ascx.cs"
    Inherits="Com.Gt.SomSc.WebApp.Controls.FilialGrid" %>
<%@ Register TagPrefix="gt" Namespace="Com.Gt.SomSc.WebApp.Controls" Assembly="Com.Gt.SomSc.WebApp" %>
<p>
    <asp:ListView ID="FiliaisListView" runat="server" DataKeyNames="Id" DataSourceID="FiliaisLinqData"
        InsertItemPosition="LastItem" OnItemCommand="FiliaisListView_ItemCommand">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="RazaoLabel" runat="server" Text='<%# Eval("Nome") %>' Width="200" />
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
                    <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' Width="200" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe um nome."
                        ValidationGroup="GroupA" ControlToValidate="NomeTextBox" />
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
                        <asp:LinkButton ID="NomeButton" runat="server" CommandName="Sort" CommandArgument="Nome"
                            Text="Nome" />
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
                    <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' Width="200" />
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Text="*" ErrorMessage="Informe um nome."
                        ValidationGroup="GroupA" ControlToValidate="NomeTextBox" />
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
<asp:LinqDataSource ID="FiliaisLinqData" runat="server" ContextTypeName="Com.Gt.SomSc.Domain.Entities.SomScDataContext"
    EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Filiais"
    OrderBy="Nome">
</asp:LinqDataSource>
