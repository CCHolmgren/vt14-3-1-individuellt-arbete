<%@ Page Title="Medlem" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="MedlemPage.aspx.cs" Inherits="Individuellt_arbete.Pages.MedlemFolder.MedlemPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server" DisplayMode="SingleParagraph"/>
    <p>Hej <asp:Label ID="FirstName" runat="server"/>!</p>
    <p><asp:Label ID="LastName" runat="server"></asp:Label>
    <asp:Label ID="PrimaryEmail" runat="server"></asp:Label></p>
    <asp:Repeater runat="server" ItemType="Individuellt_arbete.Model.RecentlyListened" ID="LastListened" SelectMethod="LastListened_GetData">
        <HeaderTemplate>
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
        </HeaderTemplate>
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
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
