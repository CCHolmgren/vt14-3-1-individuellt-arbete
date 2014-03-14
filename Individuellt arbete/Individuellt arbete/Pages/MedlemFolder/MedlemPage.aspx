<%@ Page Title="Medlem" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="MedlemPage.aspx.cs" Inherits="Individuellt_arbete.Pages.MedlemFolder.MedlemPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph"/>
    <p>Hej <asp:Label ID="FirstName" runat="server"/>!</p>
    <p><asp:Label ID="LastName" runat="server"></asp:Label>
    <asp:Label ID="PrimaryEmail" runat="server"></asp:Label></p>
    <asp:ListView runat="server" ItemType="Individuellt_arbete.Model.RecentlyListened" ID="RecentlyListenedListView" SelectMethod="RecentlyListenedListView_GetData">
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Songname</th>
                        <th>Bandname</th>
                        <th>Listened at:</th>
                        <th>Length listened</th>
                        <th>Betyg</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            </table>
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
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td>Du har inte lyssnat på några låtar, du vill kanske <asp:HyperLink NavigateUrl="<%$ RouteUrl:routename=Albums %>" runat="server">göra det</asp:HyperLink>?</td>
            </tr>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
