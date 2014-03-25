<%@ Page Title="Låtar på albumet" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Songs.aspx.cs" Inherits="Individuellt_arbete.Pages.Songs.Songs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="Successlabel"></asp:Label>
    <asp:ListView ItemType="Individuellt_arbete.Model.Song" runat="server" ID="SongList" SelectMethod="SongList_GetData" OnDataBound="SongList_DataBound">
        <LayoutTemplate>
                    <table>
                        <tr>
                            <th>Track number</th>
                            <th>Songname</th>
                            <th>BandName</th>
                            <th>Length</th>
                            <th></th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"/>
                    </table>
                    <%-- Pagination --%>
                    <%-- Invisible because we don't want there to be any pagination right now. Must probably change the PageSize though --%>
                    <asp:DataPager PagedControlID="SongList" ID="DataPager" runat="server" QueryStringField="page" PageSize="20">
                        <Fields>
                            <asp:NextPreviousPagerField ShowNextPageButton="true" ShowPreviousPageButton="true" RenderNonBreakingSpacesBetweenControls="true"/>
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" Text="<%# Item.TrackNr %>"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text="<%# Item.SongName %>"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text="<%# Item.BandName %>"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" Text="<%# Item.Length %>"></asp:Label>
                </td>
                <td>
                    <asp:Button Text="Lyssna" ID="ListenButton" OnClick="ListenButton_Click" runat="server" CommandArgument='<%# String.Format("{0},{1}",Item.SongId,Item.Length) %>' />
                    <%-- <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("ListenToSong", new {song=Item.SongId}) %>' Text="Lyssna"></asp:HyperLink>--%>
                </td>
                <%-- <td>
                    <asp:Button Text="Delete" ID="DeleteButton" OnClick="DeleteButton_Click" runat="server" CommandArgument="<%# Item.SongId %>" />
                </td>--%>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td>Det finns inga låtar associerade med albumet</td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink NavigateUrl="<%$Routeurl:routename=Albums %>" Text="Tillbaka till albumsidan" runat="server" />
                </td>
            </tr>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
