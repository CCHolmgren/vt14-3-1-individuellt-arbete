<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Songs.aspx.cs" Inherits="Individuellt_arbete.Pages.Songs.Songs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>Du befinner dig på Songs.aspx där det förhoppningsvis kommer finnas en lista med låtar, som man sedan går in på varje och kan lyssna på.</p>
    <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Default %>" Text="Hej, hemsidan" runat="server"></asp:HyperLink>
</asp:Content>
