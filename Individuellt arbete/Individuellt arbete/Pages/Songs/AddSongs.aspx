<%@ Page Title="Lägg till låtar" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AddSongs.aspx.cs" Inherits="Individuellt_arbete.Pages.Songs.AddSongs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="InsertNewRow" runat="server" OnClick="InsertNewRow_Click" Text="Lägg till låt"/>
    <asp:ListView runat="server" ID="AddSongsListView" 
        ItemType="Individuellt_arbete.Model.Song" 
        DataKeyNames="SongId" 
        SelectMethod="AddSongs_GetData" 
        InsertMethod="AddSongsListView_InsertItem" 
        ViewStateMode="Enabled" UpdateMethod="AddSongsListView_UpdateItem" DeleteMethod="AddSongsListView_DeleteItem">
        <LayoutTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>
                                Track number
                            </th>
                            <th>
                                SongName
                            </th>
                            <th>
                                BandName
                            </th>
                            <th>
                                Length
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
                <asp:DataPager PagedControlID="AddSongsListView" ID="DataPager" runat="server" QueryStringField="page" Visible="false" PageSize="200">
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Item.TrackNr %>
                    </td>
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
                        <asp:Button runat="server" ID="Edit" CommandName="Edit" Text="Redigera" />
                    </td>
                    <td></td>
                </tr>
            </ItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TrackNrEdit" Text="<%# BindItem.TrackNr %>" MaxLength="3" />
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett låtnummer." Display="None" ControlToValidate="TrackNrEdit" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="SongNameEdit" Text="<%# BindItem.SongName %>" MaxLength="45"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett låtnamn." ControlToValidate="SongNameEdit" Display="None" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="BandNameEdit" Text="<%# BindItem.BandName%>" MaxLength="50"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett bandnamn." ControlToValidate="BandNameEdit" Display="None" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="LengthEdit" Text="<%# BindItem.Length %>" MaxLength="3"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i en låtlängd" Display="None" ControlToValidate="LengthEdit" runat="server" />
                    </td>
                    <td>
                        <asp:Button runat="server" CommandName="Update" Text="Spara" ID="EditButton"/>
                    </td>
                    <td>
                        <asp:Button runat="server" CommandName="Cancel" Text="Avbryt" ID="EditCancelButton" />
                    </td>
                </tr>
            </EditItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="InsertTrackNr" Text="<%# BindItem.TrackNr %>"  MaxLength="3"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett låtnummer." Display="None" ControlToValidate="InsertTrackNr" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="InsertSongName" Text="<%# BindItem.SongName %>" MaxLength="45"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett låtnamn." ControlToValidate="InsertSongName" Display="None" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="InsertBandName" Text="<%# BindItem.BandName %>" MaxLength="50"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett bandnamn." ControlToValidate="InsertBandName" Display="None" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="InsertLength" Text="<%# BindItem.Length %>" MaxLength="3"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i en låtlängd." Display="None" ControlToValidate="InsertLength" runat="server" />
                    </td>
                    <td>
                        <asp:Button CommandName="Insert" ID="InsertButton" runat="server" Text="Lägg till"/>
                    </td>
                    <td>
                        <asp:Button Text="Avbryt" ID="CancelButton" CommandName="Cancel" runat="server" />
                    </td>
                </tr>
            </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
