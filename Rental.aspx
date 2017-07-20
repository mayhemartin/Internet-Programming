<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rental.aspx.cs" Inherits="IP_FinalProject.Rental"  MasterPageFile="~/MasterPages/Booking.Master" %>

<asp:Content ID="ContactUs" ContentPlaceHolderID="Body" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function loopRoomImages() {
            var room = <%=this.javaSerial.Serialize(getRoom()) %>;
            var pictures = <%=this.javaSerial.Serialize(getRoomImages()) %>;
            var timer;
            var x=0;

            timer = setInterval(function(){
                if(x < pictures.length){
                    setRoomImage(pictures[x], room);
                    x++;
                }
                else{
                    clearInterval(timer);
                }
            },2000);
        }
        function setRoomImage(picture, room){
            document.images.imgRoom.src = "Images/"+room+picture;
        }

    </script>
    <div style="text-align:center; margin:auto;">
        <table style="width:80%;">
            <tr>
                <td style="text-align:left;">
                    Room: </td>
                <td style="width: 70px">
                    <asp:DropDownList ID="roomsDLL" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <img name="imgRoom" src="img/loadingRoomImg.gif" alt="an error has occured" 
                        class="roomPics" height="229" width="355"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:left;">
                    <u><b>Description:</b></u> 
                
                </td>
                <td style="text-align:center;">
                    <asp:Button ID="bookIt" runat="server" Text="Book It" PostBackUrl="~/BookIt.aspx" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:left;">
                    <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
