<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlError.aspx.cs" Inherits="IP_FinalProject.SqlError" MasterPageFile="~/MasterPages/Error.Master"%>



<asp:Content ID="MainPage" ContentPlaceHolderID="Body" runat="server">
    <asp:Image ID="Image1" runat="server" Height="242px" 
        ImageUrl="~/Images/errors/sqlerror.jpg" Width="453px" /><br />
        <br />You can try to debug the error below or return to the <a href="../Defaults.aspx"><u><b>Home Page</b></u></a>
       <br /><br /><asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
</asp:Content>
