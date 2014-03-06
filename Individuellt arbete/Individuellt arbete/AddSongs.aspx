<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddSongs.aspx.cs" Inherits="Individuellt_arbete.AddSongs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <li>Längd: <asp:TextBox runat="server" ID="Length"/></li>
        <li>Namn: <asp:TextBox runat="server" ID="SongName"/></li>
        <li>BandNamn: <asp:TextBox runat="server" ID="BandName"/></li>
        <li>Album: <asp:DropDownList ID="AlbumList" runat="server"></asp:DropDownList></li>
        <li>
            <asp:Button Text="Spara" runat="server" ID="SaveSongButton"/></li>
        <li></li>
    </ul>
</asp:Content>
