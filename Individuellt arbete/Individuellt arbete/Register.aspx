<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Individuellt_arbete.Register" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="RegisterForm" Visible="false" runat="server">
        <ul>
            <li>
                Förnamn: <asp:TextBox runat="server" />
            </li>
            <li>
                Efternamn: <asp:TextBox runat="server" />
            </li>
            <li>
                EmailAddress: <asp:TextBox runat="server" />    
            </li>
            <li>
                Verifiera emailaddress: <asp:TextBox runat="server" />
            </li>
            <li>
                <asp:Button Text="Registrera" ID="RegisterButton" runat="server" OnClick="RegisterButton_Click" />
            </li>
        </ul>
    </asp:Panel>
</asp:Content>
