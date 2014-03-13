<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="Individuellt_arbete.Pages.Album.Album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server"/>
    <asp:Button Text="Nytt album" OnClick="NewAlbum_Click" ID="NewAlbum" runat="server" />
    <asp:ListView runat="server" ID="AlbumList" 
        ItemType="Individuellt_arbete.Model.Album" 
        SelectMethod="AlbumList_GetData" 
        DataKeyNames="AlbumId" 
        InsertItemPosition="None">
        <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Albumname</th>
                                <th>ReleaseYear</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"/>
                        </tbody>
                    </table>
                    <%-- Pagination --%>
                    <asp:DataPager PagedControlID="AlbumList" ID="DataPager" runat="server" QueryStringField="page" PageSize="10000">
                    </asp:DataPager>
                </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Item.AlbumName %>
                </td>
                <td>
                    <%# Item.ReleaseYear %>
                </td>
                <td>
                    <asp:HyperLink NavigateUrl='<%# GetRouteUrl("SongsGivenAlbum", new { albumid = Item.AlbumId }) %>' runat="server" Text="Lyssna"/>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <p>Kommer visa album här som man senare går in på och kan se varje låt.</p>
    <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Default %>" runat="server">Hej, hemsidan</asp:HyperLink>
</asp:Content>
