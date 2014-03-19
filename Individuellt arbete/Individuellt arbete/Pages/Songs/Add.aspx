<%@ Page Title="Lägg till låtar" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Individuellt_arbete.AddSongs" ViewStateMode="Disabled"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <li>
            <asp:Button Text="Lägg till låt" ID="AddSongButton" OnClick="AddSongButton_Click" runat="server" />
        </li>
        <li>
            <asp:ListView ID="AddSongsListView" 
            runat="server" 
            DataKeyNames="SongId" 
            ItemType="Individuellt_arbete.Model.Song" 
            SelectMethod="AddSongsListView_GetData" 
            InsertMethod="AddSongsListView_InsertItem" 
            InsertItemPosition="None" 
            DeleteMethod="AddSongsListView_DeleteItem" 
            UpdateMethod="AddSongsListView_UpdateItem" OnDataBound="AddSongsListView_DataBound">
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
                <asp:DataPager PagedControlID="AddSongsListView" ID="DataPager" runat="server" QueryStringField="page" PageSize="20">
                    <Fields>
                        <asp:NextPreviousPagerField ShowNextPageButton="true" ShowPreviousPageButton="true" RenderNonBreakingSpacesBetweenControls="true"/>
                    </Fields>
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
                        <asp:CompareValidator ErrorMessage="Du måste fylla i ett giltigt låtnummer" ControlToValidate="TrackNrEdit" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="SongNameEdit" Text="<%# BindItem.SongName %>" MaxLength="45"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett låtnamn" ControlToValidate="SongNameEdit" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="BandNameEdit" Text="<%# BindItem.BandName%>" MaxLength="50"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett bandnamn" ControlToValidate="BandNameEdit" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="LengthEdit" Text="<%# BindItem.Length %>" MaxLength="3"/>
                        <asp:CompareValidator ErrorMessage="Du måste fylla en giltig längd" ControlToValidate="LengthEdit" Type="Integer" Operator="DataTypeCheck" runat="server" />
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
                        <asp:CompareValidator ErrorMessage="Du måste fylla i ett giltigt låtnummer" ControlToValidate="InsertTrackNr" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="InsertSongName" Text="<%# BindItem.SongName %>" MaxLength="45"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett låtnamn" ControlToValidate="SongNameEdit" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="InsertBandName" Text="<%# BindItem.BandName %>" MaxLength="50"/>
                        <asp:RequiredFieldValidator ErrorMessage="Du måste fylla i ett bandnamn" ControlToValidate="BandNameEdit" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="InsertLength" Text="<%# BindItem.Length %>" MaxLength="3"/>
                        <asp:CompareValidator ErrorMessage="Du måste fylla en giltig längd" ControlToValidate="LengthEdit" Type="Integer" Operator="DataTypeCheck" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="Lägg till" ID="InsertButton" CommandName="Insert" runat="server" />
                    </td>
                    <td>
                        <asp:Button Text="Avbryt" ID="CancelButton" CommandName="Cancel" runat="server" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td>Det finns inga låtar associerade med albumet. Om du vill lägga till låtar så kan du använda knappen här ovan.</td>
                </tr>
            </EmptyDataTemplate>
        </asp:ListView>
        </li>
    </ul>
</asp:Content>
