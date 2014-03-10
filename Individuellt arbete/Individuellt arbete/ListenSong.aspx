<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListenSong.aspx.cs" Inherits="Individuellt_arbete.ListenSong" ViewStateMode="Disabled"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label" runat="server"></asp:Label>
    <asp:Repeater runat="server" ID="SongRepeater" ItemType="Individuellt_arbete.Model.Song" SelectMethod="SongRepeater_GetData">
        <ItemTemplate><%# Item.SongName + " " + Item.BandName %><asp:Button Text="Betygsätt" runat="server" /></ItemTemplate>
    </asp:Repeater>
</asp:Content>
