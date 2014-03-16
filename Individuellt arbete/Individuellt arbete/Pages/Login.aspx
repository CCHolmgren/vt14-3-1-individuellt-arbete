<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Individuellt_arbete.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="Login" runat="server" />
    <asp:DropDownList runat="server" ID="MemberList" ViewStateMode="Enabled"></asp:DropDownList>
    <asp:Button Text="Login" ID="MedlemIdSet" OnClick="MedlemIdSet_Click" runat="server" />
</asp:Content>
