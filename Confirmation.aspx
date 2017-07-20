<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="IP_FinalProject.Confirmation" MasterPageFile="~/MasterPages/Booking.Master"  %>

<asp:Content ID="ContactUs" ContentPlaceHolderID="Body" runat="server">
<script type="text/javascript">
    function alertConfirm() {
        alert("Reservation is pending. We will contact you within 24 hours. Please print this Page.");
    }
    function alertDuplicate() {
        alert("It appears another customer with your credentials already exists. Please enter different credentials.");
    }
</script>
    <div class="center" id="Greeting" style="background-color:Aqua;">
        <asp:Label ID="confirmRoom" runat="server" Text="Label" Font-Bold="True" 
            Font-Overline="True" Font-Underline="True"></asp:Label><br />
    </div>
    <table style="width:100%;">
        <tr>
            <td style="width: 101px" class="right">
                Check In :</td>
            <td class="left" style="width: 146px; vertical-align:top;">
                <asp:Label ID="confirmCheckIn" runat="server" Text="Label"></asp:Label>
            </td>
            <td colspan="2" rowspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="right">
                Check Out :</td>
            <td class="left" style="vertical-align:top; width: 146px;">
                <asp:Label ID="confirmCheckOut" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="right">
                Nights : </td>
            <td class="left" style="vertical-align:top; width: 146px;">
                <asp:Label ID="confirmNumNights" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:left; background-color:Aqua;">
                <u><b>Contact Information :</b></u></td>
        </tr>
        <tr>
            <td style="width: 101px" class="right">
                First Name :</td>
            <td class="left" style="width: 146px">
                <asp:Label ID="confirmFirstName" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="width: 118px" class="right">
                Primary Phone :</td>
            <td class="left">
                <asp:Label ID="confirmPrimaryNumber" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 101px" class="right">
                Last Name :</td>
            <td  class="left" style="width: 146px">
                <asp:Label ID="confirmLastName" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="width: 118px" class="right">
                Secondary Phone :</td>
            <td class="left">
                <asp:Label ID="confirmSecondaryNumber" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 101px" class="right">
                Email :</td>
            <td colspan="3" class="left">
                <asp:Label ID="confirmEmail" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:left; background-color:Aqua;">
                &nbsp;
                <b><u>Message from Customer</u></b></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:left;">
                <asp:Label ID="confirmMessage" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="4"><br />
                
                <asp:Button ID="confirm" runat="server" Text="Confirm" onClick="reserve_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblConfirmation" runat="server" Text="Label" Visible="False"></asp:Label>
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cancel" runat="server" Text="Cancel" onClick="cancel_Click"/>
            </td>
        </tr>
    </table>
    &nbsp;
</asp:Content>
