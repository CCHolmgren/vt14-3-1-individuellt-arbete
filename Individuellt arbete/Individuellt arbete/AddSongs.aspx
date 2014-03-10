<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddSongs.aspx.cs" Inherits="Individuellt_arbete.AddSongs" ViewStateMode="Disabled"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server" />
    <ul>
        <asp:Repeater runat="server" ItemType="Individuellt_arbete.Model.Song" ID="AddedSongsRepeater" SelectMethod="AddedSongsRepeater_GetData">
            <HeaderTemplate>
                <li>Tillagda låtar:</li>
            </HeaderTemplate>
            <ItemTemplate>
                <li><%# Item.SongName %></li>
            </ItemTemplate>
        </asp:Repeater>
        <li>Längd: <asp:TextBox runat="server" ID="Length"/></li>
        <li>Namn: <asp:TextBox runat="server" ID="SongName"/></li>
        <li>BandNamn: <asp:TextBox runat="server" ID="BandName"/></li>
        <li>Album: <asp:DropDownList ID="AlbumList" runat="server" ItemType="Individuellt_arbete.Model.Album" ViewStateMode="Enabled"></asp:DropDownList></li>
        <li>
            <asp:Button Text="Spara" runat="server" ID="SaveSongButton" OnClick="SaveSongButton_Click"/></li>
        <li></li>
    </ul>
</asp:Content>
