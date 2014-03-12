﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Songs.aspx.cs" Inherits="Individuellt_arbete.Pages.Songs.Songs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server"/>
    <asp:ListView ItemType="Individuellt_arbete.Model.Song" runat="server" ID="SongList" SelectMethod="SongList_GetData">
        <LayoutTemplate>
                    <table>
                        <tr>
                            <th>Songname</th>
                            <th>BandName</th>
                            <th>Length</th>
                            <th></th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"/>
                    </table>
                    <%-- Pagination --%>
                    <%-- Invisible because we don't want there to be any pagination right now. Must probably change the PageSize though --%>
                    <asp:DataPager PagedControlID="SongList" ID="DataPager" Visible="false" runat="server" QueryStringField="page" PageSize="20">
                        <Fields>
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
        <ItemTemplate>
            <tr>
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
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("ListenToSong", new {song=Item.SongId}) %>' Text="Lyssna"></asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Default %>" Text="Hej, hemsidan" runat="server"></asp:HyperLink>
</asp:Content>