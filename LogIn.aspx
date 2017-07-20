<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="IP_FinalProject.LogIn" MasterPageFile="~/MasterPages/Template.Master" %>

<asp:Content ID="LoginPage" ContentPlaceHolderID="Body" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 176px" class="right">
                Username :</td>
            <td class="left">
                <asp:TextBox ID="usernametxt" runat="server" Width="171px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 176px" class="right">
                Password :</td>
            <td class="left">
                <asp:TextBox ID="passwordtxt" runat="server" Width="171px" TextMode="Password" 
                    ForeColor="Black"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" 
        Visible="False"></asp:Label>
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Log In" 
        onclick="btnLogin_Click" />
    </asp:Content>