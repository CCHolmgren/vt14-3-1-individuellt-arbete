<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Individuellt_arbete.Register" ViewStateMode="Disabled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="RegisterForm" runat="server">
        <ul>
            <li>
                Förnamn: 
            </li>
            <li>
                <asp:TextBox ID="FirstName" MaxLength="45" runat="server" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" Display="Dynamic" ErrorMessage="Du måste fylla i ett förnamn.">*</asp:RequiredFieldValidator>
            </li>
            <li>
                Efternamn: 
            </li>
            <li>
                <asp:TextBox runat="server" MaxLength="45" ID="LastName"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" Display="Dynamic" ErrorMessage="Du måste fylla i ett efternamn.">*</asp:RequiredFieldValidator>
            </li>
            <li>
                EmailAddress: 
            </li>
            <li>
                <asp:TextBox runat="server" MaxLength="50" ID="PrimaryEmail"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrimaryEmail" ErrorMessage="Du måste fylla i en emailaddress i det här fältet." Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ValidationExpression="^.+@.+$" ControlToValidate="PrimaryEmail" ErrorMessage="Du måste fylla i en giltig emailaddress." Display="Dynamic">*</asp:RegularExpressionValidator>    
            </li>
            <li>
                Verifiera emailaddress: 
            </li>
            <li>
                <asp:TextBox runat="server" MaxLength="50" ID="PrimaryEmailVerify"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PrimaryEmailVerify" Display="None" ErrorMessage="Du måste fylla i samma emailaddress i det här fältet.">*</asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ControlToValidate="PrimaryEmailVerify" ControlToCompare="PrimaryEmail" ErrorMessage="Du måste fylla i samma emailaddress i båda fälten." Display="None">*</asp:CompareValidator>
            </li>
            <li>
                <asp:Button Text="Registrera" ID="RegisterButton" runat="server" OnClick="RegisterButton_Click" CausesValidation="true"/>
            </li>
        </ul>
    </asp:Panel>
</asp:Content>
