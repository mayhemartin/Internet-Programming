<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmRentals.aspx.cs" Inherits="IP_FinalProject.ConfirmRentals" MasterPageFile="~/MasterPages/Admin.Master"%>

<asp:Content ID="MainPage" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript">
    function test() {
        alert("so far so good, screw details view");
    }
</script>
    &nbsp;<table style="width:100%;">
        <tr>
            <td style="width: 356px; text-align:center;" colspan="2">
                <b><u>Pending Reservations</u></b></td>
        </tr>
        <tr>
            <td style="width: 356px; text-align:center;" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                    CellPadding="4" DataSourceID="pending" EnableModelValidation="True" 
                    GridLines="Horizontal" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" Width="542px">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="roomID" HeaderText="roomID" 
                            SortExpression="roomID" />
                        <asp:BoundField DataField="checkIn" HeaderText="checkIn" 
                            SortExpression="checkIn" />
                        <asp:BoundField DataField="nights" HeaderText="nights" 
                            SortExpression="nights" />
                        <asp:BoundField DataField="custID" HeaderText="custID" 
                            SortExpression="custID" />
                        <asp:BoundField DataField="message" HeaderText="message" 
                            SortExpression="message" Visible="False" />
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 146px">
                <asp:Label ID="lblReservation" runat="server" Text="Reservation Details" 
                    Visible="False"></asp:Label>
            </td>
            <td style="text-align:center;">
                <asp:Label ID="lblCalendar" runat="server" Text="Current Calendar"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 146px">
                <asp:DetailsView ID="DetailsView2" runat="server" Height="103px" Width="200px" 
                    AutoGenerateRows="False" BackColor="White" BorderColor="#336666" 
                    BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                    DataSourceID="pendingDetails" EnableModelValidation="True" 
                    GridLines="Horizontal" Visible="False">
                    <EditRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <Fields>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                            ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="roomID" HeaderText="roomID" 
                            SortExpression="roomID" />
                        <asp:BoundField DataField="checkIn" HeaderText="checkIn" 
                            SortExpression="checkIn" />
                        <asp:BoundField DataField="nights" HeaderText="nights" 
                            SortExpression="nights" />
                        <asp:BoundField DataField="custID" HeaderText="custID" 
                            SortExpression="custID" />
                        <asp:BoundField DataField="message" HeaderText="message" 
                            SortExpression="message" />
                    </Fields>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                </asp:DetailsView>
            </td>
            <td style="text-align:center; vertical-align:top;" rowspan="3">Room:
                <asp:DropDownList ID="dllRooms" runat="server" Height="16px" Width="76px" 
                    onselectedindexchanged="dllRooms_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                <br /><br />
                <asp:Calendar ID="bookingCalendar" runat="server" Height="114px" Width="339px" OnDayRender="bookingCalendar_DayRender"></asp:Calendar>
                <asp:Button ID="confirmPending" runat="server" 
        Text="Confirm Reservation" onclick="confirmPending_Click" Visible="False" />
    <asp:Button ID="deletePending" runat="server" Text="Delete Reservation" Visible="False" 
                    onclick="deletePending_Click" /><br /><br />
                <asp:Button ID="cancel" runat="server" Text="Cancel" onclick="cancel_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 146px">
                <asp:Label ID="lblCustomer" runat="server" Text="Customer Details" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 146px">
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                    CellPadding="4" DataSourceID="customers" EnableModelValidation="True" 
                    GridLines="Horizontal" Height="50px" Width="200px" Visible="False">
                    <EditRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <Fields>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="firstName" HeaderText="firstName" 
                            SortExpression="firstName" />
                        <asp:BoundField DataField="lastName" HeaderText="lastName" 
                            SortExpression="lastName" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                        <asp:BoundField DataField="cell" HeaderText="cell" SortExpression="cell" />
                    </Fields>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                </asp:DetailsView>
            </td>
        </tr>
        </table>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:SqlDataSource ID="customers" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CondoRoomsConnectionString %>" 
        SelectCommand="SELECT ID, firstName, lastName, email, phone, cell FROM Customers WHERE (ID = @ID)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="ID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="pending" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CondoRoomsConnectionString %>" 
        
        SelectCommand="SELECT [roomID], [checkIn], [nights], [custID], [message], [id] FROM [Pending]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="pendingDetails" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CondoRoomsConnectionString %>" 
        
        SelectCommand="SELECT [id], [roomID], [checkIn], [nights], [custID], [message] FROM [Pending] WHERE ([id] = @id)">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
&nbsp;    
    </asp:Content>
