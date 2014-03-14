<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditAlbum.aspx.cs" Inherits="Individuellt_arbete.Pages.Album.EditAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server"/>
    <asp:Button Text="Nytt album" OnClick="NewAlbum_Click" ID="NewAlbum" runat="server" />
    <asp:ListView runat="server" ID="AlbumList" 
        ItemType="Individuellt_arbete.Model.Album" 
        SelectMethod="AlbumList_GetData" 
        DataKeyNames="AlbumId" 
        InsertItemPosition="None" 
        InsertMethod="AlbumList_InsertItem" 
        UpdateMethod="AlbumList_UpdateItem" 
        DeleteMethod="AlbumList_DeleteItem">
        <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Albumname</th>
                                <th>ReleaseYear</th>
                                <th></th>
                                <th></th>
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
                    <asp:Button Text="Redigera" CommandName="Edit" runat="server" />
                </td>
                <td>
                    <asp:Button Text="Ta bort" CommandName="Delete" runat="server" />
                </td>
                <td>
                    <asp:Button Text="Lägg till låtar" OnClick="AddSongsButton_Click" CommandArgument="<%# Item.AlbumId %>" ID="AddSongsButton" runat="server"/>
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox Text="<%# BindItem.AlbumName %>" ID="EditName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox Text="<%# BindItem.ReleaseYear %>" ID="EditReleaseYear" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button CommandName="Update" ID="UpdateButton" runat="server" Text="Uppdatera"/>
                </td>
                <td>
                    <asp:Button CommandName="Cancel" ID="CancelUpdateButton" runat="server" Text="Avbryt" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox Text="<%# BindItem.AlbumName %>" ID="InsertName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox Text="<%# BindItem.ReleaseYear %>" ID="InsertReleaseYear" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button CommandName="Insert" ID="InsertButton" runat="server" Text="Lägg till"/>
                </td>
                <td>
                    <asp:Button CommandName="Cancel" ID="CancelInsertButton" runat="server" Text="Avbryt" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>
    <p>Kommer visa album här som man senare går in på och kan se varje låt.</p>
    <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Default %>" runat="server">Hej, hemsidan</asp:HyperLink>
</asp:Content>
