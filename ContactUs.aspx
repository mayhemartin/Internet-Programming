<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="IP_FinalProject.ContactUs" MasterPageFile="~/MasterPages/Template.Master" %>

<asp:Content ID="ContactUs" ContentPlaceHolderID="Body" runat="server">
    <table style="width:100%;">
    <tr>
        <td style="width: 146px" class="right">
            From :</td>
        <td class="left">
            <asp:TextBox ID="fromtxt" runat="server" Width="248px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px" class="right">
            Subject :</td>
        <td class="left">
            <asp:TextBox ID="subjecttxt" runat="server" Width="248px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 146px" class="right">
            Message :</td>
        <td class="left">
            <asp:TextBox ID="messagetxt" runat="server" Width="251px" Height="95px" 
                TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Send Email" 
                onclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblNotify" runat="server" Text="Label" Visible="False"></asp:Label>
            <br />
            <br />
        </td>
    </tr>
</table>
&nbsp;
</asp:Content>
