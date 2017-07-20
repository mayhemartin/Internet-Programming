<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookIt.aspx.cs" Inherits="IP_FinalProject.BookIt"  MasterPageFile="~/MasterPages/Booking.Master"  %>

<asp:Content ID="ContactUs" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript">
        function postGreeting() {
            var room = <%=this.javaSerial.Serialize(getRoom()) %>;
            var greeting = "Your interested in room <b>"+room+"</b> !!";
            document.getElementById('Greeting').innerHTML = greeting;
        }
        function clearText(txtBoxID){
            document.getElementById("email").value="";
        }
    </script>
    <div class="center" style="text-align:left; background-color:Aqua;" id="Greeting"><script type="text/javascript">postGreeting();</script></div>
    <table style="width:100%;">
        <tr>
            <td style="width: 122px" class="right">
                Check In :</td>
            <td class="left" style="width: 146px; vertical-align:top;">
                <asp:TextBox ID="checkIn" runat="server" Width="93px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="checkInCalendar" runat="server" 
                    ImageUrl="~/img/Calendar.bmp" onclick="checkInCalendar_Click" />
            </td>
            <td colspan="2" rowspan="2" style="text-align:center;">
                <asp:Calendar ID="checkInBigCalendar" runat="server" Visible="False" OnDayRender="checkInBigCalendar_DayRender" 
                    onselectionchanged="checkInBigCalendar_SelectionChanged">
                </asp:Calendar>
                <asp:Label ID="pendingKey" runat="server" ForeColor="#00CC00" 
                    Text="Green = Pending Reservation" Visible="False"></asp:Label>
                <br />
                <asp:Label ID="reservedKey" runat="server" ForeColor="Red" 
                    Text="Red = Confirmed Reservation" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="right" style="width: 122px; ">
                Number of Nights :</td>
            <td class="left" style="vertical-align:top; width: 146px; ">
                <asp:DropDownList ID="dllNights" runat="server" Height="16px" Width="75px">
                </asp:DropDownList>
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:left; background-color:Aqua;">
                <u><b>Contact Information :</b></u></td>
        </tr>
        <tr>
            <td style="width: 122px" class="right">
                First Name :</td>
            <td class="left" style="width: 146px">
                <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 118px" class="right">
                Last Name :</td>
            <td class="left">
                <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 122px" class="right">
                Primary Phone :</td>
            <td  class="left" style="width: 146px">
                <asp:TextBox ID="primaryNumber" runat="server"></asp:TextBox>
            </td>
            <td style="width: 118px" class="right">
                Secondary Phone :</td>
            <td class="left">
                <asp:TextBox ID="cellNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 122px" class="right">
                &nbsp;</td>
            <td colspan="3" class="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="vertical-align:top;">
                Email :&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="email" runat="server" Width="273px" ForeColor="Black"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="vertical-align:top;">
                Message:
                <asp:TextBox ID="mssg" runat="server" Height="84px" TextMode="MultiLine" 
                    Width="278px">Enter a message for our staff.</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="reserve" runat="server" Text="Reserve" onClick="reserve_Click"/>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;
</asp:Content>
