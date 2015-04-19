<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Com.Gt.SomSc.WebApp.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::: Controle SomSC - Entrar :::</title>
    <link href="~/Css/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="LoginForm" runat="server">
    <div class="topContent">
        Controle SomSC
    </div>
    <asp:Login ID="SiteLogin" runat="server" CssClass="loginContent" OnAuthenticate="SiteLogin_Authenticate"
        FailureText="Apelido ou senha inválidos. Tente novamente.">
        <LayoutTemplate>
            <table border="0" cellpadding="2">
                <tr>
                    <td align="center" colspan="2">
                        Entrar
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Apelido:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ToolTip="Informe o Apelido." Text="*" ValidationGroup="SiteLogin" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            ToolTip="Informe a senha." Text="*" ValidationGroup="SiteLogin" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" style="color: Red;">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="SiteLogin"
                            CssClass="button" />
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>
    <div class="footerContent">
        &copy; 1979-2012 Giancarlo Tomazelli. Todos os direitos reservados.
    </div>
    </form>
</body>
</html>
