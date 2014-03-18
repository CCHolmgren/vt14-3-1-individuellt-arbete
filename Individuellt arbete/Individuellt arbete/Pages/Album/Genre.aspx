﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Genre.aspx.cs" Inherits="Individuellt_arbete.Pages.Album.Genre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <li>
            <asp:Button Text="Lägg till genre" ID="AddGenreButton" OnClick="AddGenreButton_Click" runat="server" />
        </li>
        <li>
            <asp:ListView ID="AddGenreListView" 
            runat="server" 
            DataKeyNames="GenreId" 
            ItemType="Individuellt_arbete.Model.AlbumHasGenre" 
            SelectMethod="AddGenreListView_GetData" 
            InsertMethod="AddGenreListView_InsertItem"
            InsertItemPosition="None" 
            DeleteMethod="AddGenreListView_DeleteItem" OnItemInserting="AddGenreListView_ItemInserting">
            <LayoutTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>
                                GenreName
                            </th>
                            <th>
                            </th>
                            <th>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                    </tbody>
                </table>
                <asp:DataPager Visible="false" PagedControlID="AddGenreListView" ID="DataPager" runat="server" QueryStringField="page" PageSize="200">
                        </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Item.Genre %>
                    </td>
                    <td>
                        <asp:Button Text="Ta bort" ID="RemoveButton" CommandName="Delete" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td>
                        <asp:DropDownList runat="server" ID="GenreDDL" />
                    </td>
                    <td>
                        <asp:Button Text="Lägg till" ID="InsertButton" OnClick="InsertButton_Click" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="Avbryt" ID="CancelButton" CommandName="Cancel" runat="server" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td>Det finns inga genrer associerade med albumet. Om du vill lägga till genrer så kan du använda knappen här ovan.</td>
                </tr>
            </EmptyDataTemplate>
        </asp:ListView>
        </li>
    </ul>
</asp:Content>