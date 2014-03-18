<%@ Page Title="Medlem" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="MedlemPage.aspx.cs" Inherits="Individuellt_arbete.Pages.MedlemFolder.MedlemPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="HelloMessage" Visible="false"><p>Hej <asp:Label ID="FirstName" runat="server"/>!</p></asp:Panel>
    <p><asp:Label ID="LastName" runat="server"></asp:Label>
    <asp:Label ID="PrimaryEmail" runat="server"></asp:Label></p>
    <asp:ListView runat="server" 
        ItemType="Individuellt_arbete.Model.RecentlyListened" 
        ID="RecentlyListenedListView" 
        SelectMethod="RecentlyListenedListView_GetData">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Songname</th>
                        <th>Bandname</th>
                        <th>Listened at:</th>
                        <th>Length listened</th>
                        <th>Betyg</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            </table>
            <asp:DataPager runat="server" PageSize="5" Visible="false"/>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Item.SongName %>
                </td>
                <td>
                    <%#Item.BandName %>
                </td>
                <td>
                    <%#Item.Date %>
                </td>
                <td>
                    <%#Item.Length %>
                </td>
                <td>
                    <%#Item.Betyg %>
                </td>
                <asp:Panel Visible="true" ID="GradePanel" runat="server">
                    <td>
                        <asp:DropDownList OnSelectedIndexChanged="Unnamed_SelectedIndexChanged" AutoPostBack="true" runat="server" db-SongId="<%# Item.SongId %>">
                            <asp:ListItem Value="1">
                                1
                            </asp:ListItem>
                            <asp:ListItem Value="2">
                                2
                            </asp:ListItem>
                            <asp:ListItem Value="3">
                                3
                            </asp:ListItem>
                            <asp:ListItem Value="4">
                                4
                            </asp:ListItem>
                            <asp:ListItem Value="5">
                                5
                            </asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </asp:Panel>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td>Du har inte lyssnat på några låtar, du vill kanske <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Albums %>" runat="server">göra det</asp:HyperLink>?</td>
            </tr>
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>Användaren har inte lyssnat på några låtar än.</td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
