<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="Com.Gt.SomSc.DynApp.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />