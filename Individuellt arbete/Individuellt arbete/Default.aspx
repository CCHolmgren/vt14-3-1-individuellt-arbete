<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/SiteMaster.Master" Inherits="Individuellt_arbete.Default" ViewStateMode="Disabled"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <asp:Label Text="text" runat="server" ID="Label"/>
    <asp:TextBox runat="server" ID="MedlemId" OnTextChanged="MedlemId_TextChanged"/>
    <asp:Button Text="text" ID="MedlemIdSet" OnClick="MedlemIdSet_Click" runat="server" />
    <asp:TextBox runat="server" ID="TextBox1" OnTextChanged="TextBox1_TextChanged"/>

    <asp:Repeater runat="server" ItemType="Individuellt_arbete.Model.Album" SelectMethod="Unnamed_GetData">
        <ItemTemplate><%# Item.AlbumName %></ItemTemplate>
    </asp:Repeater>
</asp:Content>