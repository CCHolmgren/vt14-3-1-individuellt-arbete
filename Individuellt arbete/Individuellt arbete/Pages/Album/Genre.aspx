<%@ Page Title="Lägg till genre" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Genre.aspx.cs" Inherits="Individuellt_arbete.Pages.Album.Genre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="AlbumName"/>
    <ul>
        <asp:Repeater runat="server" ID="AlbumGenreRpr" ItemType="Individuellt_arbete.Model.AlbumHasGenre" SelectMethod="AlbumGenreRpr_GetData">
            <ItemTemplate>
                <li>
                    <%# Item.Genre %>
                </li>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
        <li><asp:DropDownList runat="server" ID="NewGenreDDL" /><asp:Button runat="server" ID="AddGenreButton" Text="Lägg till genre" OnClick="AddGenreButton_Click"/></li>
    </ul>
</asp:Content>
