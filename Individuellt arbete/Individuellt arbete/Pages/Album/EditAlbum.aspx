<%@ Page Title="Redigera album" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditAlbum.aspx.cs" Inherits="Individuellt_arbete.Pages.Album.EditAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button Text="Nytt album" OnClick="NewAlbum_Click" ID="NewAlbum" runat="server" />
    <asp:ListView runat="server" ID="AlbumList" ViewStateMode="Enabled" 
        ItemType="Individuellt_arbete.Model.Album" 
        SelectMethod="AlbumList_GetData" 
        DataKeyNames="AlbumId" 
        InsertItemPosition="None" 
        InsertMethod="AlbumList_InsertItem" 
        UpdateMethod="AlbumList_UpdateItem" 
        DeleteMethod="AlbumList_DeleteItem" OnDataBound="AlbumList_DataBound">
        <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Albumnamn</th>
                                <th>Utgivningsår</th>
                                <th></th>
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
                    <asp:DataPager PagedControlID="AlbumList" ID="DataPager" runat="server" QueryStringField="page" PageSize="20">
                        <Fields>
                            <asp:NextPreviousPagerField ShowNextPageButton="true" ShowPreviousPageButton="true" RenderNonBreakingSpacesBetweenControls="true" PreviousPageText="Förra" NextPageText="Nästa"/>
                        </Fields>
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
                    <asp:LinkButton OnclientClick="return confirm('Är du säker på att du vill ta bort albumet permanent?')" Text="Ta bort" CommandName="Delete" runat="server" />
                </td>
                <td>
                    <asp:Button Text="Lägg till låtar" OnClick="AddSongsButton_Click" CommandArgument="<%# Item.AlbumId %>" ID="AddSongsButton" runat="server"/>
                </td>
                <td>
                    <asp:Button Text="Lägg till genre" ID="AddGenreButton" runat="server" CommandArgument="<%# Item.AlbumId %>" OnClick="AddGenreButton_Click" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox Text="<%# BindItem.AlbumName %>" ID="EditName" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EditName" Display="None" ErrorMessage="Du måste fylla i ett Albumnamn" />
                </td>
                <td>
                    <asp:TextBox Text="<%# BindItem.ReleaseYear %>" ID="EditReleaseYear" runat="server" MaxLength="4"></asp:TextBox>
                    <asp:RangeValidator ControlToValidate="EditReleaseYear" runat="server" MinimumValue="1500" Display="None" MaximumValue="2020" ErrorMessage="Du måste ange ett utgivningsår mellan 1500 och 2020"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EditReleaseYear" Display="None" ErrorMessage="Du måste fylla i ett utgivningsår" />
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
                    <asp:TextBox Text="<%# BindItem.AlbumName %>" ID="InsertName" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="InsertName" Display="None" ErrorMessage="Du måste fylla i ett Albumnamn" />
                </td>
                <td>
                    <asp:TextBox Text="<%# BindItem.ReleaseYear %>" ID="InsertReleaseYear" runat="server" MaxLength="4"></asp:TextBox>
                    <asp:RangeValidator ControlToValidate="InsertReleaseYear" runat="server" MinimumValue="1500" MaximumValue="2020" Display="None" ErrorMessage="Du måste ange ett utgivningsår mellan 1500 och 2020"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="InsertReleaseYear" Display="None" ErrorMessage="Du måste fylla i ett releaseyear" />
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
    <p>
        <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Albums %>" runat="server" Text="Gå tillbaka till albumsidan"/>
    </p>
</asp:Content>
