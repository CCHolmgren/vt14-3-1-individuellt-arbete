<%@ Page Title="Medlem" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="MedlemPage.aspx.cs" Inherits="Individuellt_arbete.Pages.MedlemFolder.MedlemPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph"/>
    <p>Hej <asp:Label ID="FirstName" runat="server"/>!</p>
    <asp:Label ID="LastName" runat="server"></asp:Label>
    <asp:Label ID="PrimaryEmail" runat="server"></asp:Label>
    <asp:Repeater runat="server" ItemType="Individuellt_arbete.Model.RecentlyListened" ID="LastListened" SelectMethod="LastListened_GetData">
        <ItemTemplate><%# Item.SongName %></ItemTemplate>
    </asp:Repeater>
</asp:Content>
