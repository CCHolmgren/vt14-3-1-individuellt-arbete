<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/SiteMaster.Master" Inherits="Individuellt_arbete.Default" ViewStateMode="Disabled"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <asp:Label Text="text" runat="server" ID="Label"/>

    <asp:Repeater runat="server" ItemType="Individuellt_arbete.Model.Album" SelectMethod="Unnamed_GetData">
        <ItemTemplate><%# Item.AlbumName %></ItemTemplate>
        <AlternatingItemTemplate>hello<br /><%# Item.AlbumName %></AlternatingItemTemplate>
    </asp:Repeater>

</asp:Content>