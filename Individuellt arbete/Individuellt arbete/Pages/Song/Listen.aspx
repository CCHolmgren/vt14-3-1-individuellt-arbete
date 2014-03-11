<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Listen.aspx.cs" Inherits="Individuellt_arbete.Pages.Songs.Listen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Hej du befinner dig just nu i song/listen
    <asp:HyperLink ID="DefaultHyperLink" runat="server" NavigateUrl="<%$ RouteUrl:routename=Default %>" Text="Hej, hemsidan"/>
    <asp:Label Text="<%$ RouteValue:medlem %>" runat="server"></asp:Label>
</asp:Content>
