<%@ Page Title="Album" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="Individuellt_arbete.Pages.Album.Album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <asp:Button Text="Nytt album" OnClick="NewAlbum_Click" ID="NewAlbum" runat="server" />--%>
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
    <asp:Button ID="AddAlbumButton" Text="Lägg till album" runat="server" OnClick="AddAlbumButton_Click" />
</asp:Content>
