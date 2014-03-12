<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="Individuellt_arbete.Pages.Album.Album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>Kommer visa album här som man senare går in på och kan se varje låt.</p>
    <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Default %>" runat="server">Hej, hemsidan</asp:HyperLink>
</asp:Content>
