<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Individuellt_arbete.AddSongs" ViewStateMode="Disabled"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server" />
    <asp:ListView ID="AddSongsListView" 
        runat="server" 
        DataKeyNames="SongId" 
        ItemType="Individuellt_arbete.Model.Song" 
        SelectMethod="AddSongsListView_GetData" 
        InsertMethod="AddSongsListView_InsertItem" 
        InsertItemPosition="LastItem" 
        DeleteMethod="AddSongsListView_DeleteItem" 
        UpdateMethod="AddSongsListView_UpdateItem">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>
                            What is this
                        </th>
                        <th>
                            th second
                        </th>
                        <th>
                            what
                        </th>
                        <th>
                            yes
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                </tbody>
            </table>
            <asp:DataPager Visible="false" PagedControlID="AddSongsListView" ID="DataPager" runat="server" QueryStringField="page" PageSize="10000">
                    </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# Item.SongName %>
                </td>
                <td>
                    <%# Item.BandName %>
                </td>
                <td>
                    <%# Item.Length %>
                </td>
                <td>
                    what
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    Edit
                </td>
                <td>
                    Edit second
                </td>
                <td>
                    Edit third
                </td>
                <td>
                    Edit fourth
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="InsertSongName" Text="<%# BindItem.SongName %>"/>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="InsertBandName" Text="<%# BindItem.BandName %>"/>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="InsertLength" Text="<%# BindItem.Length %>"/>
                </td>
                <td>
                    <asp:Button Text="Lägg till" ID="InsertButton" CommandName="Insert" runat="server" />
                </td>
                <td>
                    <asp:Button Text="Avbryt" ID="CancelButton" CommandName="Cancel" runat="server" />
                </td>
            </tr>
        </InsertItemTemplate>
        <EmptyDataTemplate></EmptyDataTemplate>
    </asp:ListView>
    <%-- <ul>
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
    </ul>--%>
</asp:Content>
